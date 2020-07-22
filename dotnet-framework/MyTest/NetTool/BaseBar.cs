using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTool.UserControls;

namespace NetTool
{
    public class BaseBar :UserControl
    {
        public delegate bool Notify(string ip, string port);
        public event Notify Evt_ConnectServer;
        public event Notify Evt_DisConnectServer;
        public event Notify Evt_StartServer;
        public event Notify Evt_StopServer;

        public BaseBar(SocketType type)
        {
            this.Type = type;
        }
        public BaseBar()
        {

        }
        public SocketType Type { get; set; }
        public virtual string IP { get; set; }
        public virtual string Port { get; set; }

        public virtual void SetBtnState(string type)
        {
        }

        public virtual void ConnectServer()
        {
            if (Evt_ConnectServer!=null)
            {
                this.Evt_ConnectServer.Invoke(IP,Port);
            }
        }
        public virtual void DisConnectServer()
        {
            if (Evt_DisConnectServer != null)
            {
                this.Evt_DisConnectServer.Invoke(IP, Port);
            }
        }
        public virtual void StartServer()
        {
            if (Evt_StartServer != null)
            {
                this.Evt_StartServer.Invoke(IP, Port);
            }
        }
        public virtual void StopServer()
        {
            if (Evt_StopServer != null)
            {
                this.Evt_StopServer.Invoke(IP, Port);
            }
            
        }
    }
}
