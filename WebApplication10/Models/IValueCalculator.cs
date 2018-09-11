using System.Collections.Generic;

namespace WebApplication10.Models
{
    /// <summary>
    /// 创建接口
    /// </summary>
    public interface IValueCalculator
    {
        /// <summary>
        /// 得到Products数量的方法
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        decimal ValueProducts(IEnumerable<Product> products);
    }
}