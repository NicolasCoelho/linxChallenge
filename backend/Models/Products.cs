using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string code { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public DateTime createdAt { get; set; }
    }
}