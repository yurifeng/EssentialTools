using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class ShoppingCart
    {
        /// <summary>
        /// 将求和的类添加为自己的私有字段(耦合)
        /// </summary>
        private LinqValueCalculator calc;

        /// <summary>
        /// 构造方法传入求和的类
        /// </summary>
        /// <param name="calcParam"></param>
        public ShoppingCart(LinqValueCalculator calcParam)
        {
            calc = calcParam;
        }

        /// <summary>
        /// 创建自己的自动属性(Products)
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// 自己的求Product的价格总和的方法
        /// (方法体内其实是用了LinqValueCalculator的ValueProducts求和方法)
        /// </summary>
        /// <returns></returns>
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }
    }
}