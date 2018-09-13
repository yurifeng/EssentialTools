// 
// 1.项目要用到Ninject,是一种DI容器
// 
// 
// 2.创建Product实体类(里面包括价格属性):
// 
//     public class Product 
// 	{
//         public int ProductID { get; set; }
//         public string Name { get; set; }
//         public string Description { get; set; }
//         public decimal Price { get; set; }
//         public string Category { set; get; }
//     }
// 
// 
// 3.创建LinqValueCalculator类,里面有个方法ValueProducts是计算总价的方法:
//     
//     public class LinqValueCalculator
// 	{
//         public decimal ValueProducts(IEnumerable<Product> products) 
// 		{
//             return products.Sum(p => p.Price);
//         }
//     }
//     
// 
// 4.创建ShoppingCart实体类,有Product集合,使用LinqValueCalculator计算总价:
// 
// 	public class ShoppingCart
// 	{
// 		private LinqValueCalculator calc;
// 
// 		public ShoppingCart(LinqValueCalculator calcParam)
// 		{
// 			calc = calcParam;
// 		}
// 
// 		public IEnumerable<Product> Products { get; set; }
// 
// 		public decimal CalculateProductTotal()
// 		{
// 			return calc.ValueProducts(Products);
// 		}
// 	}
// 
// 5.添加控制器HomeController:
// 
// 	public class HomeController : Controller
// 	{
// 		//创建Products数组对象
// 		private Product[] products =
//         {
//             new Product{Name="yty",Category="Sports", Price=250},
//             new Product{Name="livid",Category="Home",Price=300},
//             new Product{Name="htt",Category="Study",Price=180},
//             new Product{Name="jsd",Category="Sports",Price=280},
//             new Product{Name="jt",Category="Study",Price=320},
//             new Product{Name="hst",Category="Study",Price=330},
//         };
// 
// 		public ActionResult Index()
//         {
//             //实例化LinqValueCalculator
//             IValueCalculator iValueCalculator = new LinqValueCalculator();
// 
//             //实例化ShoppingCart
//             ShoppingCart shoppingCart = new ShoppingCart(iValueCalculator)
//             {
//                 Products = products
//             };
// 
//             //计算总价格(用decimal来接)
//             decimal totalValue = shoppingCart.CalculateProductTotal();
// 
//             //返回视图View
//             return View(totalValue);
//         }
// 	}
// 
// 6.添加View视图:
// 	@model decimal
// 
// 	@{
// 		ViewBag.Title = "Products Price Count";
// 		Layout = null;
// 	 }
// 
// 		Total Value: $@Model
// 
// 
// 7.