using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.BasketDto;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public List<Basket> GetBasketByTableNumber(int id)
        {
            return _basketDal.GetBasketByTableNumber(id);
        }

        public void TAdd(Basket entity)
        {
            _basketDal.Add(entity);
        }

        public void TDelete(Basket entity)
        {
            _basketDal.Delete(entity);
        }

        public List<Basket> TGetAll()
        {
            return _basketDal.GetAll();
        }

        public Basket TGetById(int id)
        {
            return _basketDal.GetById(id);
        }

        public void TUpdate(Basket entity)
        {
           _basketDal.Update(entity);   
        }
    }
}
