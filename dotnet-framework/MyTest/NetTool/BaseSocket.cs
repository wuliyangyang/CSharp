using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTool
{
    class BaseSocket
    {
        public event MsgHandler Evt_RecvMsg;
        public event MsgHandler Evt_SendMsg;
        public event MsgHandler Evt_ErrorMsg;

        public string IP { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public SocketType Type { get; set; }

        public BaseSocket(string ip, int port,SocketType type)
        {
            this.IP = ip;
            this.Port = port;
            this.Type = type;
        }
        public void SetConfig(string ip, int port)
        {
            this.IP = ip;
            this.Port = port;
        }
        public virtual void SendString(string msg)
        {
        }
        public virtual string ReadString()
        {
            return "";
        }
        public virtual bool  Start()
        {
            return true;
        }
        public virtual bool Stop()
        {
            return true;
        }
        public virtual bool Connect()
        {
            return true;
        }
        public virtual bool Disconnect()
        {
            return true;
        }
        public virtual void RecvMsgHandler(string msg)
        {
            if (Evt_RecvMsg!=null)
            {
                Evt_RecvMsg.Invoke(msg);
            }
        }
        public virtual void SendMsgHandler(string msg)
        {
            if (Evt_SendMsg != null)
            {
                Evt_SendMsg.Invoke(msg);
            }
        }
        public virtual void ErrorMsgHandler(string msg)
        {
            if (Evt_ErrorMsg != null)
            {
                Evt_ErrorMsg.Invoke(msg);
            }
        }
    }
}
