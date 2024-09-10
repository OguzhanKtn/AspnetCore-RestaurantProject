using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
	public class NotificationManager : INotificationService
	{
		private readonly INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal = notificationDal;
		}

		public int NotificationCountByStatusFalse()
		{
			return _notificationDal.NotificationCountByStatusFalse();
		}

		public void TAdd(Notification entity)
		{
			_notificationDal.Add(entity);
		}

		public void TDelete(Notification entity)
		{
			_notificationDal.Delete(entity);
		}

		public List<Notification> TGetAll()
		{
			return _notificationDal.GetAll();
		}

		public Notification TGetById(int id)
		{
			return _notificationDal.GetById(id);
		}

		public void TUpdate(Notification entity)
		{
			_notificationDal.Update(entity);
		}
	}
}
