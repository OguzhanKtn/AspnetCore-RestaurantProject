using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.BasketDto;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }
  
        public List<Basket> GetBasketByTableNumber(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Where(x => x.TableID == id).Include(y => y.Product).ToList();
            return values;
        }
    }
}
