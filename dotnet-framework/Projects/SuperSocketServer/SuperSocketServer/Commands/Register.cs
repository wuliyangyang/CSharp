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
    public class  Register: CommandBase<ChatSession,StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                ChatSession oldChatSession = session.AppServer.GetAllSessions().FirstOrDefault(a => requestInfo.Parameters[0].Equals(a.Id));
                if (oldChatSession != null)
                {
                    oldChatSession.Send("your accout is logined in somewhere else");
                    oldChatSession.Close();
                }
                session.Id = requestInfo.Parameters[0];
                session.PassWord = requestInfo.Parameters[1];
                session.IsRegister = true;
                session.LoginTime = DateTime.Now;
                //Console.WriteLine($"ready to send to {session.Id}");
                session.Send("login successfully");

                MsgManager.SendOffLineMsg(session.Id, c => session.Send($"{c.FromId} send :{c.Message} {c.Id}"));
            }
            else
            {
                session.Send("parameter error");
            }
        }
    }
}
