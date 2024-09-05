using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _ProductDal;

        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public int GetProductCount()
        {
            return _ProductDal.GetProductCount();
        }

        public List<Product> GetProductsWithCategories()
        {
            return _ProductDal.GetProductsWithCategories();
        }

        public void TAdd(Product entity)
        {
            _ProductDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _ProductDal.Delete(entity);
        }

        public List<Product> TGetAll()
        {
            return _ProductDal.GetAll();
        }

        public Product TGetById(int id)
        {
            return _ProductDal.GetById(id);
        }

        public decimal TProductAvgPriceByHamburger()
        {
            return _ProductDal.ProductAvgPriceByHamburger();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _ProductDal.ProductCountByCategoryNameDrink();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _ProductDal.ProductCountByCategoryNameHamburger();
        }

        public string TProductNameByMaxPrice()
        {
            return _ProductDal.ProductNameByMaxPrice();
        }

        public string TProductNameByMinPrice()
        {
            return _ProductDal.ProductNameByMinPrice();
        }

        public decimal TProductPriceAvg()
        {
            return _ProductDal.ProductPriceAvg();
        }

        public decimal TProductPriceBySteakBurger()
        {
            return _ProductDal.ProductPriceBySteakBurger();
        }

        public decimal TTotalPriceByDrinkCategory()
        {
            return _ProductDal.TotalPriceByDrinkCategory();
        }

        public decimal TTotalPriceBySaladCategory()
        {
            return _ProductDal.TotalPriceBySaladCategory();
        }

        public void TUpdate(Product entity)
        {
            _ProductDal.Update(entity);
        }
    }
}
