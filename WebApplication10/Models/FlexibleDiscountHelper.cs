namespace WebApplication10.Models
{
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal totalParam)
        {
            decimal discount = totalParam > 100 ? 70 : 50;
            return (totalParam - (discount / 100m * totalParam));
        }
    }
}