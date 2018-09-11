using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    /// <summary>
    /// 创建查询Product的价格总和
    /// </summary>
    public class LinqValueCalculator
    {
        /// <summary>
        /// 用Linq的Sum方法求和
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}