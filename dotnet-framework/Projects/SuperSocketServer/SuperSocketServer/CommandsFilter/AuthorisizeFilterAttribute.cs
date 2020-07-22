using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;
using SuperSocketServer.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.CommandsFilter
{
  public  class AuthorisizeFilterAttribute : CommandFilterAttribute
    {
        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {
           
        }

        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            ChatSession session = (ChatSession)commandContext.Session;
            string cmdName = commandContext.CurrentCommand.Name;
            if (!session.IsRegister)
            {

                if (!cmdName.Equals("Register"))
                {
                    session.Send("pls Register first");
                    commandContext.Cancel = true;
                }
                else
                {
                    //register
                }
            }
            else
            {
                session.Send("parameter error");
            }
        }
    }
}
