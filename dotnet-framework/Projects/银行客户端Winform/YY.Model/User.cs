using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Model
{
    public class User
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public double Money { get; set; }
        public DateTime LastMoneyTime { get; set; }
    }
}
