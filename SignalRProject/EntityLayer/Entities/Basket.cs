namespace EntityLayer.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int TableID { get; set; }
        public Table Table { get; set; }
        public int UserID { get; set; }
        public AppUser User { get; set; }
    }
}
