using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.BasketDto
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public Product Product { get; set; }   
        public int TableID { get; set; }
        
    }
}
