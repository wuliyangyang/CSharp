using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BNS.Model;
using BNS.IDAl;
using Common;

namespace BNS.DAL
{
    public class RoleServiceDAL : IRoleService
    {
        static string tableName = ConfigurationManager.AppSettings["Table"];
        public RoleServiceDAL()
        {

        }
        public int Delete(int id)
        {
            string deleteCmd = @"delete from  " + tableName + " where SId=" + id.ToString();
            return DBHelper.Update(deleteCmd);
        }

        public int Insert(BNSRole role)
        {
            string insertCmd = @"insert into " + tableName + " values(" + role.ToString() + ")";
            return DBHelper.Update(insertCmd);
        }

        public bool IsExist(string name)
        {
            string queryCmd = @"select SName from " + tableName + " where SName=" +"\'"+ name+"\'";
            int ret = DBHelper.Update(queryCmd);
            return ret == -1 ? true : false;
        }

        public BNSRole Query(int id)
        {
            string queryCmd = @"select * from " + tableName + " where SId=" + id.ToString();
            return QueryAction(queryCmd);
        }

        public BNSRole Query(string name)
        {
            string queryCmd = @"select * from " + tableName + " where SName=" + "\'" + name + "\'";
            return QueryAction(queryCmd);
        }

        private BNSRole QueryAction(string queryCmd)
        {
            DataTable dt = DBHelper.Query(queryCmd);
            BNSRole role = new BNSRole();
            foreach (DataRow row in dt.Rows)
            {
                role.SId = Convert.ToInt32(row["SId"]);
                role.Race = row["Race"].ToString();
                role.Gender = row["Gender"].ToString();
                role.Profession = row["Profession"].ToString();
                role.SName = row["SName"].ToString();
                break;
            }
            return role;
        }
    }
}
