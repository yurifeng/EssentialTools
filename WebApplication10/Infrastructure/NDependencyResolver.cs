using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using WebApplication10.Models;

namespace WebApplication10.Infrastructure
{
    /// <summary>
    /// Ninject的准备工作在此类完成
    /// </summary>
    public class NDependencyResolver : IDependencyResolver//该类实现IDependencyResolver接口
    {

        /// <summary>
        /// 将IKernel作为该类的私有字段
        /// </summary>
        private IKernel kernel;

        /// <summary>
        /// 构造方法(传入IKernel接口)
        /// 该构造方法由App_Start中的NinjectWebCommon类使用
        /// </summary>
        /// <param name="kernelParam"></param>
        public NDependencyResolver(IKernel kernelParam)
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
            //内核绑定IValueCalculator接口,实例化的是LinqValueCalculator
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            //设置属性
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);

            //当Discount类使用构造方法时
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);

            //最终会创建LinqValueCalculator对象WhenInjectedInto
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }


        /// <summary>
        /// 实现IDependencyResolver接口要重写的GetService方法
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        /// <summary>
        /// 实现IDependencyResolver接口要重写的返回为泛型的方法
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}