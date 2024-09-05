﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>,IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }

        public int PassiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Status == false).Count();
        }

        public int TotalCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Status == true).Count();
        }
    }
}
