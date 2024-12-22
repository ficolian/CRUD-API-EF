namespace Fish.Entity.SQL
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public DateTime createdAt { get; set; }
    }
}
