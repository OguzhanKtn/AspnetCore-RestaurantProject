
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>,IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Reservation Confirmed";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new SignalRContext();
			var values = context.Bookings.Find(id);
			values.Description = "Reservation Cancelled";
			context.SaveChanges();
		}
	}
}
