using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTool
{
    public delegate void PostMsg(string cmd);
    public delegate void MsgHandler(string msg);
    public delegate void PostMsgHandler(object sender);
    public class DataModel
    {
    }

   public enum SocketType
    {
        TcpServer,
        TcpClient,
        SerialPort,
        Rep,
        Req,
        Pub,
        Sub
    }
    public enum Model
    {
        Tcp,
        Serial,
        NMQ
    }
    public enum LogMode
    {
        Send,
        Recv
    }

}
