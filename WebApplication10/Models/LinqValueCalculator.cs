using System.Collections.Generic;
using System.Linq;

namespace WebApplication10.Models
{

    /// <summary>
    /// 创建查询Product的价格总和
    /// </summary>
    public class LinqValueCalculator : IValueCalculator
    {
        /// <summary>
        /// 用Linq的Sum方法求和
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public decimal ValueProducts(IEnumerable<Product> products) => products.Sum(p => p.Price);
    }
}