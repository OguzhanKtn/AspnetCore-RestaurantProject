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

		public List<Notification> GetAllNotifications()
		{
			using var context = new SignalRContext();
			var values = context.Notifications.Where(x => x.Status == false).ToList();
			return values;
		}

		public void MakeNotificationStatusTrue(int id)
		{
			using var context = new SignalRContext();
			var notification = context.Notifications.Find(id);
			notification.Status = true;
			context.SaveChanges();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).Count();
		}
	}
}
