using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.Concrete
{
	public class EfMessageDal : GenericRepository<Message>, IMessageDal
	{
		public EfMessageDal(SignalRContext context) : base(context)
		{
		}
	}
}
