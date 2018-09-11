using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using WebApplication10.Models;

namespace WebApplication10.Infrastructure
{
    /// <summary>
    /// 该类用于Ninject的DI容器运作,将减少控制器的负担(况且这些也不是控制器该操心的)
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver//该类实现IDependencyResolver接口
    {
        /// <summary>
        /// 将IKernel作为该类的私有字段
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// 该类的构造方法(传入IKernel接口)
        /// </summary>
        /// <param name="kernelParam"></param>
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            //调用下面已经配置好的内核
            AddBindings();
        }

        /// <summary>
        /// 将设置内核作为一个方法
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}