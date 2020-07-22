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
    class DBHelper
    {
        static string conStr = ConfigurationManager.ConnectionStrings["sqlString"].ConnectionString; //"server=.;database=MyTest;uid=sa;pwd=sa";
        /// <summary>
        /// 增 删 改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int UpdateSql(string sql)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                int ret = command.ExecuteNonQuery();
                con.Close();

                return ret;
            }
        }
        public static int Scalar(string sql)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
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
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        public static DataTable QuerySql(string sql)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                DataTable dataTable = new DataTable();
                SqlCommand command = new SqlCommand(sql, con);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    return dataTable;
                }
            }
        }

        public static void QuerySql2(string sql)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                DataTable dataTable = new DataTable();
                SqlCommand command = new SqlCommand(sql, con);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["SId"].ToString() + "  " + reader["Race"].ToString() + "  " + reader["Gender"].ToString() + "  " + reader["Profession"].ToString() + "  " + reader["SName"].ToString());
                    }
                }
            }
        }
    }
}
