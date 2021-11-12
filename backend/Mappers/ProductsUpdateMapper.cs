using System.ComponentModel.DataAnnotations;

namespace backend.Mappers
{
    public class ProductsUpdateMapper
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public string image { get; set; }
    }
}