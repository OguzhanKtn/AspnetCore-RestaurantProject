using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {      
       
        public EfBasketDal(SignalRContext context) : base(context)
        {           
        }

        public List<ResultBasketDto> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
        
            var result = context.Baskets
                .Where(b => b.UserID == id)
                .GroupBy(b => new { b.ProductID, b.UserID, b.Price })
                .Select(group => new ResultBasketDto
                {
                    Id = group.First().Id,  
                    ProductName = group.First().Product.Name,
                    UserID = group.Key.UserID,
                    Count = group.Sum(b => b.Count),
                    Price = group.Key.Price,
                    TotalPrice = group.Sum(b => b.Count * b.Price)
                })
                .ToList();

            return result;
        }

        //public List<Basket> GetBasketByTableNumber(int id)
        //{
        //    using var context = new SignalRContext();
        //    var values = context.Baskets.Where(x => x.TableID == id).Include(y => y.Product).ToList();
        //    return values;
        //}


    }
}
