using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public int TableCount()
        {
            return _tableDal.TableCount();
        }

        public void TAdd(Table entity)
        {
            _tableDal.Add(entity);
        }

        public void TDelete(Table entity)
        {
            _tableDal.Delete(entity);
        }

        public List<Table> TGetAll()
        {
            return _tableDal.GetAll();  
        }

        public Table TGetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public void TUpdate(Table entity)
        {
            _tableDal.Update(entity);
        }
    }
}
