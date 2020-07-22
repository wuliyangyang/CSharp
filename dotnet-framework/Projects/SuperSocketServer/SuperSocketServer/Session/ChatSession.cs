using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.Session
{
    public class ChatSession: AppSession<ChatSession>
    {
        public string Id { get; set; }
        public string PassWord { get; set; }
        public bool IsRegister { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LastHBTime { get; set; }
        public bool IsOnline { get { return this.LastHBTime.AddSeconds(10) > DateTime.Now; } }
        protected override void OnInit()
        {
            base.OnInit();
        }
        protected override void OnSessionStarted()
        {
            
        }
        protected override void HandleException(Exception e)
        {
            //收到命令不符合规则进入道这里
            base.HandleException(e);
        }

        public override void Send(string message)
        {
            base.Send(message);
        }
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }
        protected override string ProcessSendingMessage(string rawMessage)
        {
            return base.ProcessSendingMessage(rawMessage);
        }

    }
}
