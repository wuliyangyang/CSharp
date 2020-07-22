using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    //General Manager
    public class GM:AbstructAudit
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"{this.GetType().Name} 审批中。。。");
            if (context.Hour < 108 && context.AuditResult == false)
            {
                Console.WriteLine($"{this.GetType().Name} 审批完成,同意请假!!");
                context.AuditRemark = "批准";
                context.AuditResult = true;
            }
            else
            {
                base.AuditNext(context);
            }
        }
    }
}
