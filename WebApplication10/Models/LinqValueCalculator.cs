using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
// ReSharper disable All

namespace WebApplication10.Models
{

    /// <summary>
    /// 创建查询Product的价格总和
    /// </summary>
    public class LinqValueCalculator : IValueCalculator
    {
        #region 没有使用IDiscount接口

        ////<summary>
        ////用Linq的Sum方法求和
        ////</summary>
        ////<param name="products"></param>
        ////<returns></returns>
        //public decimal ValueProducts(IEnumerable<Product> products)
        //{
        //    return products.Sum(p => p.Price);
        //}

        #endregion

        /// <summary>
        /// 将IDiscountHelper作为字段
        /// </summary>
        private IDiscountHelper _discounter;

        private static int _counter = 0;

        /// <summary>
        /// 构造方法传入IDiscountHelper接口
        /// </summary>
        /// <param name="discountParam"></param>
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            _discounter = discountParam;
            Debug.WriteLine($"实例{++_counter}被创建");
        }

        /// <summary>
        /// 重写的IValueCalculator方法,用IDiscountHelper计算打折
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            //products.Sum(p => p.Price)返回的是总价格
            //_discounter.ApplyDiscount正好计算打折后的价格
            return _discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}