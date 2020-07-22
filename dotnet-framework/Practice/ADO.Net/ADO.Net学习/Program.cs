using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO.Net学习
{
    class Program
    {
        static void Main(string[] args)
        {
            //string cmd = "insert into UserInfo values('zhangsan1002','mima1002')";
            //int ret =  DBHelper.UpdateSql(cmd);
            //Console.WriteLine(ret);

            //获取时间
            string cmd = "select * from BNS";//"select getdate()";
            DataTable dt =  DBHelper.QuerySql(cmd);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(string.Join(" ", row.ItemArray));
            }
            Console.WriteLine("-------------------------------------------------------------------------");

            DBHelper.QuerySql2(cmd);

            Console.WriteLine(DBHelper.Scalar($"select count(*) from BNS"));

            Console.ReadKey();
        }

    }
}
