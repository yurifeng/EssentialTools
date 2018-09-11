﻿using System.Web.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    /// <summary>
    /// 该控制器中,ShoppingCart和LinqValueCalculator与HomeController紧耦合
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 硬编码创建Product对象数组
        /// </summary>
        private Product[] products =
        {
            new Product{Name="yty",Category="Sports", Price=250},
            new Product{Name="livid",Category="Home",Price=300},
            new Product{Name="htt",Category="Study",Price=180},
            new Product{Name="jsd",Category="Sports",Price=280},
            new Product{Name="jt",Category="Study",Price=320},
            new Product{Name="hst",Category="Study",Price=330},
        };

        /// <summary>
        /// 将接口作为私有属性
        /// </summary>
        private IValueCalculator calculator;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="calcParam"></param>
        public HomeController(IValueCalculator calcParam)
        {
            calculator = calcParam;
        }

        public HomeController()
        {
            
        }

        /// <summary>
        /// 返回视图的方法
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ShoppingCart shoppingCart = new ShoppingCart(calculator) { Products = products };
            decimal totalCount = shoppingCart.CalculateProductTotal();
            return View(totalCount);
        }


        //<summary>
        //动作中有很严重的依赖耦合
        //</summary>
        //<returns></returns>
        //public ActionResult Index()
        //{
        //    //实例化LinqValueCalculator
        //    IValueCalculator iValueCalculator = new LinqValueCalculator();
        //    //实例化ShoppingCart
        //    ShoppingCart shoppingCart = new ShoppingCart(iValueCalculator)
        //    {
        //        Products = products
        //    };
        //    //计算总价格(用decimal来接)
        //    decimal totalValue = shoppingCart.CalculateProductTotal();
        //    //返回视图View
        //    return View(totalValue);
        //}



        //虽然用上了Ninject,但是效果不彻底
        //public ActionResult Index()
        //{
        //    //实例化IKernel的实现类StandardKernel(简言之:就是创建DI容器的内核实例)
        //    IKernel iKernel = new StandardKernel();

        //    //配置Ninject内核(使其内核知道程序员要用到的接口和实例)
        //    iKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

        //    //内核的Get方法表示:内核已经获得程序员想要的接口的实例,用原接口来接收
        //    IValueCalculator iValueCalculator = iKernel.Get<IValueCalculator>();

        //    //创建ShoppingCart实例
        //    ShoppingCart cart = new ShoppingCart(iValueCalculator) { Products = products };

        //    //ShoppingCart实例调用CalculateProductTotal方法,得出总价格
        //    decimal calcTotal = cart.CalculateProductTotal();

        //    return View(calcTotal);
        //}
    }
}