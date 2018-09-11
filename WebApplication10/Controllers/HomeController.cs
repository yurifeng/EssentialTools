using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            new Product{Name="livir",Category="Home",Price=300},
            new Product{Name="htt",Category="Study",Price=180},
            new Product{Name="jsd",Category="Sports",Price=280},
            new Product{Name="jt",Category="Study",Price=320},
            new Product{Name="hst",Category="Study",Price=330},
        };

        /// <summary>
        /// 动作中有很严重的依赖耦合
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //实例化LinqValueCalculator
            LinqValueCalculator linqValueCalculator = new LinqValueCalculator();
            //实例化ShoppingCart
            ShoppingCart shoppingCart = new ShoppingCart(linqValueCalculator)
            {
                Products = products
            };
            //计算总价格(用decimal来接)
            decimal calculateProductTotal = shoppingCart.CalculateProductTotal();
            //返回视图View
            return View(calculateProductTotal);
        }
    }
}