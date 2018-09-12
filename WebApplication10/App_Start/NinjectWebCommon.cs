using System.Web.Mvc;
using Ninject;
using WebApplication10.Infrastructure;

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
            //将自创建的NinjectDependencyResolver(kernel)
            //用DependencyResolver的SetResolver方法注册成解析器
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}