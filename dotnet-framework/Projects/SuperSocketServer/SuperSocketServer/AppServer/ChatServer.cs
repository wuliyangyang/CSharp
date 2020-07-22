using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocketServer.CommandsFilter;
using SuperSocketServer.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.AppServer
{
    [AuthorisizeFilterAttribute]
    public class ChatServer:AppServer<ChatSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            Console.WriteLine("read config file");
            return base.Setup(rootConfig, config);
        }
        
        protected override void OnSessionClosed(ChatSession session, CloseReason reason)
        {
            Console.WriteLine($"{session.LocalEndPoint.Address} {session.LocalEndPoint.Port} Session Close");
            base.OnSessionClosed(session, reason);
        }
        protected override void OnNewSessionConnected(ChatSession session)
        {
            Console.WriteLine($"New Session {session.LocalEndPoint.Address} {session.LocalEndPoint.Port} Come In");
            base.OnNewSessionConnected(session);
            session.Send("welcome to ChatServer".Format());
        }
        protected override void OnStarted()
        {
            Console.WriteLine("Chat Server Started ");
            base.OnStarted();
        }
        protected override void OnStopped()
        {
            Console.WriteLine("Chat Server Stopped ");
            base.OnStopped();
        }

    }
}
