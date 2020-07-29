using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode3.Decorators.Interface
{
    public abstract class AbstractPayCallback
    {
        protected IPayCallback _payCallback;
        public AbstractPayCallback(IPayCallback payCallback)
        {
            this._payCallback = payCallback;
        }
    }
}
