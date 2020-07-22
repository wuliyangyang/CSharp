using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNS.Model
{
    public class BNSRole
    {
        public int SId { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string SName { get; set; }

        public BNSRole()
        {

        }
        public override string ToString()
        {
            string s = "\'"+this.Race+ "\'" + "," + "\'" + this.Gender + "\'" + "," + "\'" + this.Profession + "\'" + "," + "\'" + this.SName+ "\'";
            return s;
        }
    }
}
