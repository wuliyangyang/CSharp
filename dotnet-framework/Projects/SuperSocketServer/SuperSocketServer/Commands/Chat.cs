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
    public class Chat : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            string toId = requestInfo.Parameters[0];
            string msg = requestInfo.Parameters[1];

            ChatSession toChatSession = session.AppServer.GetAllSessions().FirstOrDefault(a => toId.Equals(a.Id));
            if (toChatSession != null)
            {
                string modelId = Guid.NewGuid().ToString();
                MsgManager.Add(toId, new ChatModel
                {
                    Id = modelId,
                    ToId = toId,
                    FromId = session.Id,
                    Message = msg,
                    CreatTime = DateTime.Now,
                    State = MsgState.Sending
                });
                toChatSession.Send($"{msg.Format()} {modelId}");
            }
            else
            {
                string modelId = Guid.NewGuid().ToString();
                MsgManager.Add(toId, new ChatModel
                {
                    Id = modelId,
                    ToId = toId,
                    FromId = session.Id,
                    Message = msg,
                    CreatTime = DateTime.Now,
                    State = MsgState.UnSend
                });
                session.Send("Failed to Send Msg".Format());
            }
        }
    }
}
