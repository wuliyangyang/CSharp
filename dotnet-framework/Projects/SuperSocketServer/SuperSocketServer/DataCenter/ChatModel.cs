using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.DataCenter
{
   public class ChatModel
    {
        public string Id { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Message { get; set; }
        public DateTime CreatTime { get; set; }
        public MsgState State { get; set; }

    }

    public enum MsgState
    {
        UnSend=0,
        Sending=1,
        Sended=2
    }
}
