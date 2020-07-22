using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    public class AuditBuilder
    {
        public static AbstructAudit  Build()
        {
            AbstructAudit gm = new GM() { Name = "总经理" };
            AbstructAudit dir = new Director { Name = "运营总监" };
            AbstructAudit bm = new BM { Name = "部门经理" };
            AbstructAudit pm = new PM { Name = "项目经理" };
            AbstructAudit sm = new SM { Name = "软件经理" };

            sm.SetNextAuditor(pm);
            pm.SetNextAuditor(bm);
            bm.SetNextAuditor(dir);
            dir.SetNextAuditor(gm);
            return sm;
        }
    }
}
