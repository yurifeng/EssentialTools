using System.Collections.Generic;

namespace WebApplication10.Models
{
    /// <summary>
    /// 该类中,ShoppingCart和LinqValueCalculator紧耦合
    /// </summary>
    public class ShoppingCart
    {
        // <summary>
        // 将求和的类添加为自己的私有字段(耦合)
        // </summary>
        //private LinqValueCalculator calc;

        /// <summary>
        /// 将接口作为字段,减少了与LinqValueCalculator类的紧耦合
        /// </summary>
        private IValueCalculator _calc;

        /// <summary>
        /// 构造方法传入求和的类
        /// </summary>
        /// <param name="calcParam"></param>
        public ShoppingCart(IValueCalculator calcParam)
        {
            _calc = calcParam;
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
            return _calc.ValueProducts(Products);
        }
    }
}