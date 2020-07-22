using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YY.Business.Interface
{
    public interface ISpiderService
    {
        void StartSpide(List<string> urls);
    }
}
