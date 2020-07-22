using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Company
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public int LastModifierId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastModifyTime { get; set; }

        public string Name { get; set; }


    }
}