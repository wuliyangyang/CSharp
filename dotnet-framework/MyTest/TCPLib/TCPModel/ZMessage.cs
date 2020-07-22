using System;
using System.Collections.Generic;
using System.Text;

namespace TCPLib
{
    /// <summary>
    /// 说明：
    /// 消息数据包，TCP通信中代表一个完整的消息
    /// </summary>
    class ZMessage
    {
        public byte head;       //消息头
        public int length;     //消息体长度
        public byte[] content;  //消息体
    }
}
