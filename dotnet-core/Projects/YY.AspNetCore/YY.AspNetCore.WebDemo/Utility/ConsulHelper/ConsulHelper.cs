using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;

namespace YY.AspNetCore.WebDemo.Utility.ConsulHelper
{
    public static class ConsulHelper
    {
        static List<string> userList = new List<string>();
        static string resultUrl = null;
        private static int iSeed = 0;
        private static string _datacenter = "dcl";
        private static string _consulUrl = "http://localhost:8500/";
        private static string _url = $"http://ImageService:8800/api/imageurl/GetUrl/";

        /// <summary>
        /// 随机策略
        /// </summary>
        /// <returns></returns>
        public static string GetUrlByRandom()
        {
            //consul解决使用服务名字 转换IP:Port----DNS

            Uri uri = new Uri(_url);
            string groupName = uri.Host;
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(_consulUrl);
                c.Datacenter = _datacenter;
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                var list = dictionary.Where(k => k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));//获取consul上全部对应服务实例
                KeyValuePair<string, AgentService> keyValuePair = new KeyValuePair<string, AgentService>();

                var array = list.ToArray();
                //随机策略---平均策略
                keyValuePair = array[new Random(iSeed++).Next(0, array.Length)];
                if (iSeed > 10000) iSeed = 0;
                resultUrl = $"{uri.Scheme}://{keyValuePair.Value.Address}:{keyValuePair.Value.Port}{uri.PathAndQuery}";
            }
            return resultUrl;
        }

        /// <summary>
        /// 轮询策略
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUrlByRoundrobin()
        {
            //consul解决使用服务名字 转换IP:Port----DNS

            Uri uri = new Uri(_url);
            string groupName = uri.Host;
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(_consulUrl);
                c.Datacenter = _datacenter;
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                var list = dictionary.Where(k => k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));//获取consul上全部对应服务实例
                KeyValuePair<string, AgentService> keyValuePair = new KeyValuePair<string, AgentService>();
                //拿到3个地址，只需要从中选择---可以在这里做负载均衡--

                var array = list.ToArray();
                //轮询策略---平均策略
                keyValuePair = array[iSeed++ % array.Length];
                if (iSeed > 10000) iSeed = 0;
                resultUrl = $"{uri.Scheme}://{keyValuePair.Value.Address}:{keyValuePair.Value.Port}{uri.PathAndQuery}";
            }
            return resultUrl;
        }
        /// <summary>
        /// 权重策略
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetUrlByWeight()
        {
            //consul解决使用服务名字 转换IP:Port----DNS
            Uri uri = new Uri(_url);
            string groupName = uri.Host;
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(_consulUrl);
                c.Datacenter = _datacenter;
            }))
            {
                var dictionary = client.Agent.Services().Result.Response;
                var list = dictionary.Where(k => k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));//获取consul上全部对应服务实例
                KeyValuePair<string, AgentService> keyValuePair = new KeyValuePair<string, AgentService>();
                //权重---注册服务时指定权重，分配时获取权重并以此为依据
                List<KeyValuePair<string, AgentService>> pairsList = new List<KeyValuePair<string, AgentService>>();
                foreach (var pair in list)
                {
                    int count = int.Parse(pair.Value.Tags?[0]);//获取权重
                    for (int i = 0; i < count; i++)
                    {
                        pairsList.Add(pair);//添加实例
                    }
                }
                keyValuePair = pairsList.ToArray()[new Random(iSeed++).Next(0, pairsList.Count())];
                if (iSeed > 10000) iSeed = 0;
                resultUrl = $"{uri.Scheme}://{keyValuePair.Value.Address}:{keyValuePair.Value.Port}{uri.PathAndQuery}";
            }
            return resultUrl;
        }
    }
}