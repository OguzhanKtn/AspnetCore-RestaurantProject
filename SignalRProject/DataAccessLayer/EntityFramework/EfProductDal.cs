using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>,IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public int GetProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public List<Product> GetProductsWithCategories()
        {
            using var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.Id).FirstOrDefault())).Average(w => w.Price);
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y=>y.Name=="Beverages").Select(z=>z.Id).FirstOrDefault())).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.Name == "Hamburger").Select(z => z.Id).FirstOrDefault())).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderByDescending(x => x.Price).First().Name;

        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.OrderByDescending(x => x.Price).Last().Name;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductPriceBySteakBurger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x =>x.Name == "Steak Burger").Select(y=>y.Price).FirstOrDefault();
        }

        public decimal TotalPriceByDrinkCategory()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(x => x.Name == "Beverages").Select(x => x.Id).FirstOrDefault())).Sum(x => x.Price);
        }

        public decimal TotalPriceBySaladCategory()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.Where(x => x.Name == "Salad").Select(x => x.Id).FirstOrDefault())).Sum(x => x.Price);
        }
    }
}
