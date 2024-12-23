namespace Fish.Application.Usecase
{
    public class GetProductData
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
    }
}
