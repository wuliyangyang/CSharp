using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode1.Strategy
{
    /// <summary>
    /// 策略选择类
    /// </summary>
   public  class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public int ExecuteStrategy(int n1,int n2)
        {
            return this._strategy.DoOperation(n1, n2);
        }
    }
}
