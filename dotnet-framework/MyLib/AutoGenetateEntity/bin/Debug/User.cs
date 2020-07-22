using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int CreatorId { get; set; }

        public int LastModifierId { get; set; }

        public DateTime LastLoginTime { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastModifyTime { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public int Id { get; set; }

        public int CompanyId { get; set; }

        /// <summary>
        /// 用户状态  0正常 1冻结 2删除
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 用户类型  1 普通用户 2管理员 4超级管理员
        /// </summary>
        public int UserType { get; set; }


    }
}