﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;

namespace BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

		public void BookingStatusApproved(int id)
		{
			_bookingDal.BookingStatusApproved(id);
		}

		public void BookingStatusCancelled(int id)
		{
			_bookingDal.BookingStatusCancelled(id);
		}

		public void TAdd(Booking entity)
        {
            _bookingDal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public List<Booking> TGetAll()
        {
            return _bookingDal.GetAll();
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
