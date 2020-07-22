using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    public abstract class AbstructAudit
    {
        private AbstructAudit abstructAudit = null;
        public string Name { get; set; }

        public abstract void Audit(ApplyContext context);
        public void SetNextAuditor(AbstructAudit audit)
        {
            this.abstructAudit = audit;
        }

        protected void AuditNext(ApplyContext context)
        {
            if (abstructAudit != null)
            {
                abstructAudit.Audit(context);
            }
            else
            {
                Console.WriteLine($"审批失败");
                context.AuditRemark = "请假失败";
                context.AuditResult = false;
            }
        }
     

    }
}
