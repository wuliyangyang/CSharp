using DesignMode3.Decorators.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Decorators
{
    public class PayCallback : IPayCallback
    {
        public void CallbackHandler()
        {
            Console.WriteLine("正常支付回调");
            // *1.发送短信
            //* 2.发送邮件
            //* 3.记录日志
        }
    }
}
