using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Data.SqlClient;

namespace AutoGenetateEntity
{
    class Program
    {
        static string nameSpaceName = "";
        static void Main(string[] args)
        {
            //获取命令空间名
            nameSpaceName = ConfigurationManager.AppSettings["namespace"];

            //查询所有表名
            string sql = "select [name] from sysobjects where xtype='U'";
            var tbs = SqlHelper.ExecuteDataTable(sql);
            foreach (DataRow row in tbs.Rows)
            {
                string tbName = row[0].ToString();

                //生成这个表的类
                string clsString = CreateTable(tbName);
                File.WriteAllText(tbName + ".cs", clsString);

                Console.WriteLine(clsString);
            }




            Console.WriteLine("生成完毕...");
            //延迟1秒半自动关闭
            Task.Run(() =>
            {
                Thread.Sleep(1500);
                Environment.Exit(0);
            });
            Console.ReadLine();


        }


        public static string CreateTable(string tbName)
        {

            //查询所有字段
            string sql = $@"
select syscolumns.name as ColName,
systypes.name as TypeName,
sys.extended_properties.value as Description,
sysobjects.name as TableName from syscolumns 
inner join sysobjects on syscolumns.id=sysobjects.id 
inner join systypes on syscolumns.xtype=systypes.xtype 
left join sys.extended_properties on sys.extended_properties.major_id=syscolumns.id and sys.extended_properties.minor_id=syscolumns.colorder 
where sysobjects.name='{tbName}' and systypes.name<>'sysname' 
order by sys.extended_properties.minor_id asc";

            var tb = SqlHelper.ExecuteDataTable(sql);

            //所有字段
            StringBuilder txt = new StringBuilder();

            foreach (DataRow row in tb.Rows)
            {
                //获取关键属性
                var colName = row[0].ToString();
                var typeName = row[1].ToString();
                var description = row[2].ToString();


                //替换类型
                typeName = Regex.Replace(typeName, "nvarchar", "string");
                typeName = Regex.Replace(typeName, "varchar", "string");
                typeName = Regex.Replace(typeName, "nchar", "string");
                typeName = Regex.Replace(typeName, "text", "string");
                typeName = Regex.Replace(typeName, "char", "string");
                typeName = Regex.Replace(typeName, "tinyint", "int");
                typeName = Regex.Replace(typeName, "smallint", "int");
                typeName = Regex.Replace(typeName, "bigint", "int");
                typeName = Regex.Replace(typeName, "money", "decimal");
                typeName = Regex.Replace(typeName, "bit", "bool");
                typeName = Regex.Replace(typeName, "datetime", "DateTime");
                typeName = Regex.Replace(typeName, "numeric", "double");
                
                //替换描述
                if (string.IsNullOrEmpty(description) == false)
                {
                    description = $@"        /// <summary>
        /// {description}
        /// </summary>
";
                }

                txt.AppendLine($"{description}        public {typeName} {colName} {{ get; set; }}");
                txt.AppendLine();


            }

            //整理最后文件代码
            string code = ($@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {nameSpaceName}
{{
    public class {tbName}
    {{
{txt.ToString()}
    }}
}}");

            return code;
        }

    }
}






/// <summary>
/// 牛逼的类
/// </summary>
public class SqlHelper
{

    static SqlHelper()
    {
        //core需要改下
        connStr = ConfigurationManager.AppSettings["sqlConn"];

    }
    public static string connStr;

    public static int ExecuteNonQuery(string sql, params SqlParameter[] parm)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    cmd.Parameters.AddRange(parm);
                    cmd.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return -1;
            }

        }
    }



    public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parm)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parm);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }





}
