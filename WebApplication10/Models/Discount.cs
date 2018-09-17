namespace WebApplication10.Models
{
    /// <summary>
    /// 创建了IDiscountHelper接口
    /// </summary>
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }

    /// <summary>
    /// 创建类实现接口,执行接口的方法
    /// </summary>
    public class DefaultDiscountHelper : IDiscountHelper
    {
        private decimal _discountSize;

        public DefaultDiscountHelper(decimal discountParam)
        {
            _discountSize = discountParam;
        }

        public decimal ApplyDiscount(decimal totalParam)
        {
            //打1折
            return (totalParam - (_discountSize / 100m * totalParam));
        }
    }
}