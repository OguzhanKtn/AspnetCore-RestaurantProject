using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface INotificationDal : IGenericDal<Notification>
	{
		int NotificationCountByStatusFalse();
		void MakeNotificationStatusTrue(int id);
		List<Notification> GetAllNotifications();
	}
}
