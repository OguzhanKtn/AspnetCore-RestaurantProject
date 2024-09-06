using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;


namespace DataAccessLayer.EntityFramework
{
    public class EfTableDal : GenericRepository<Table>,ITableDal
    {
        public EfTableDal(SignalRContext context) : base(context)
        {
        }

        public int TableCount()
        {
           using var context = new SignalRContext();   
           return context.Tables.Count();
        }
    }
}
