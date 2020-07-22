using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CommonLibs
{
    public class DBHelper
    {
        static string conStr = ConfigurationManager.ConnectionStrings["sqlString"].ConnectionString; //"server=.;database=MyTest;uid=sa;pwd=sa";
         // static string tableName = ConfigurationManager.AppSettings["Table"];
         /// <summary>
         /// 增 删 改
         /// </summary>
         /// <param name="sql"></param>
         /// <returns></returns>
        public static int ENQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    int ret = command.ExecuteNonQuery();
                    return ret;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public static int ENQuery(string sql,SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddRange(sqlParameters);
                    int ret = command.ExecuteNonQuery();
                    return ret;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public static int Scalar(string sql)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    int ret = Convert.ToInt32(command.ExecuteScalar());
                    return ret;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        /// <summary>
        /// 查
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataTable Query(string cmd, SqlParameter[] sqlParameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.Parameters.AddRange(sqlParameters);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception){}
            return dt;
        }
    }
}
