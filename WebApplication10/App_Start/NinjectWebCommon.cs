using System.Web.Mvc;
using Ninject;
using Ninject.Web.Mvc;

namespace WebApplication10
{
    public class NinjectWebCommon
    {
        /// <summary>
        /// 在该类中注册依赖项解析器
        /// </summary>
        /// <param name="kernel"></param>
        private static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}