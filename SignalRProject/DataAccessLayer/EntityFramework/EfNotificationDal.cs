using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).Count();
		}
	}
}
