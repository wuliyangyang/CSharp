using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNS.BLL;
using BNS.Model;


namespace BNS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            RoleServiceBLL serviceBLL = new RoleServiceBLL();
            BNSRole role = new BNSRole()
            {
                Race = "人族",
                Gender = "男",
                Profession = "拳师",
                SName = "千甄拳"
            };

             serviceBLL.Insert(role);
            string result = serviceBLL.Query(2).ToString().Replace(" ", "");
            Console.WriteLine("查询结果：{0}", result);

            Console.WriteLine()
            Console.ReadKey();
        }
    }
}
