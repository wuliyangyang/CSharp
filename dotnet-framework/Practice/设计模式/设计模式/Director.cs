using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    //运营总监 
    public class Director:AbstructAudit
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"{this.GetType().Name} 审批中。。。");
            if (context.Hour < 72 && context.AuditResult == false)
            {
                Console.WriteLine($"{this.GetType().Name} 审批完成,同意请假!!");
                context.AuditRemark = "批准";
                context.AuditResult = true;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} 无权限");
                base.AuditNext(context);
            }
        }
    }
}
