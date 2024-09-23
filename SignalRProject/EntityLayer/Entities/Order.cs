using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
