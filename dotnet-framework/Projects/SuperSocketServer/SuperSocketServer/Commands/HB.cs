using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketServer.DataCenter;
using SuperSocketServer.Session;
namespace SuperSocketServer.Commands
{
    class HB : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                string HBStr = requestInfo.Parameters[0];
                if ("R".Equals(HBStr))
                {
                    session.LastHBTime = DateTime.Now;
                    session.Send("R");
                }

            }
            else
            {
                session.Send("parameter error");
            }
        }
    }
}
