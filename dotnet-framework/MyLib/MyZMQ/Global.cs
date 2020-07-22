using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace MyZMQ
{
    static class Global
    {
        private static readonly object lockObj = new object();
        static internal ZContext UniqueZContext = new ZContext();
        static internal ZContext GetUniqueContext()
        {
            return UniqueZContext;
        }
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">标字符串的长度</param>
        /// <param name="useNum">是否使用数字</param>
        /// <param name="useLow">是否使用小写字母</param>
        /// <param name="useUpp">是否使用大写字母</param>
        /// <param name="useSpe">是否使用特殊字符</param>
        /// <param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        /// <returns></returns>
        public static string GetRandomString(int length = 10, bool useNum = true, bool useLow = true, bool useUpp = true, bool useSpe = true, string custom = "")
        {
            lock (lockObj)
            {
                byte[] b = new byte[4];
                new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
                Random r = new Random(BitConverter.ToInt32(b, 0));
                string s = null, str = custom;
                if (useNum == true) { str += "0123456789"; }
                if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
                if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
                if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
                for (int i = 0; i < length; i++)
                {
                    s += str.Substring(r.Next(0, str.Length - 1), 1);
                }
                return s;
            }

        }
        public static String GetDateTimeString()
        {
            //DateTime.Now.ToLongTimeString().ToString(); //format now DateTime: 11:05:12
            return DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss:zz.fffff");//format now DateTime: 2013-6-19 09:45:30.12345
        }
    }
}
