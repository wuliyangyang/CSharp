using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Injection;

namespace YY.SOA.WebApi
{
    public class IOCDependencyResolver : IDependencyResolver
    {
        private IUnityContainer unityContainer = null;
        public IOCDependencyResolver(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
        public IDependencyScope BeginScope()
        {
            return new IOCDependencyResolver(this.unityContainer.CreateChildContainer());
        }

        public void Dispose()
        {
            if (this.unityContainer!=null) this.unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.unityContainer.Resolve(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}