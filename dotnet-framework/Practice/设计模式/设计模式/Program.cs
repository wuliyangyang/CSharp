using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplyContext context = new ApplyContext()
            {
                AuditRemark = "请假",
                AuditResult = false,
                Hour = 200,
                Id = "123456",
                Name = "张三"

            };

            AbstructAudit audit = AuditBuilder.Build();
            audit.Audit(context);
            if (context.AuditResult==false)
            {
                Console.WriteLine("离职");
            }
            Console.ReadKey();
        }
    }
}
