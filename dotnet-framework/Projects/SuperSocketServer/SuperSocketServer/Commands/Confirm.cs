using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocketServer.DataCenter;
using SuperSocketServer.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.Commands
{
    public class Confirm : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                string modelId = requestInfo.Parameters[0];
                MsgManager.UpdateMsgState(session.Id, modelId);
            }
            else if(!session.IsOnline)
            {
                session.LastHBTime = DateTime.Now;
            }
        }
    }
}
