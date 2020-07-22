using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace YY.MVC5
{
    public class YYControllerFactory : DefaultControllerFactory
    {
        Logger logger = new Logger(typeof(YYControllerFactory));
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            logger.Info("IOC 开始!!");
            IUnityContainer container = ContainerFactory.GetContainer();

            return (IController)container.Resolve(controllerType);
        }
    }
}