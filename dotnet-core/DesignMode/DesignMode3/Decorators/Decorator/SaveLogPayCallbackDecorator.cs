﻿using DesignMode3.Decorators.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Decorators.Decorator
{
    public class SaveLogPayCallbackDecorator : AbstractPayCallback,IPayCallback
    {
        //private IPayCallback _payCallback;
        //public SendMsgPayCallbackDecorator(IPayCallback payCallback)
        //{
        //    this._payCallback = payCallback;
        //}
        public SaveLogPayCallbackDecorator(IPayCallback payCallback):base(payCallback)
        {
           
        }
        public void CallbackHandler()
        {
            //调用原有的方法
            _payCallback.CallbackHandler();

            //扩展
            SaveLog();
        }

        public void SaveLog()
        {
            Console.WriteLine($"SaveLog");
        }
         
    }
}
