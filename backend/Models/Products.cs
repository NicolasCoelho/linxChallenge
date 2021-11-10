namespace backend.Models
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public DateTime createdAt { get; set; }
    }
}