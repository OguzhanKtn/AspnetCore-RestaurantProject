﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
