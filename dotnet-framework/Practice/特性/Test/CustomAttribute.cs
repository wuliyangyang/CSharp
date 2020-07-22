using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
    public class CustomAttribute:Attribute
    {
        public CustomAttribute()
        {

        }
        public CustomAttribute(string name)
        {
            this._name = name;
        }
        public CustomAttribute(int id)
        {
            this._id = id;
        }
        private int _id = 0;
        private string _name = null;

        public string Remark { get; set; }
        public string Description { get; set; }

        public void Show()
        {
            Console.WriteLine($"{this._id} {this._name} {this.Remark} {this.Description}");
        }
    }

    public class CustomAttributeSon : CustomAttribute
    {

    }
}
