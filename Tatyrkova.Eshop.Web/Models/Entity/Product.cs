using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tatyrkova.Eshop.Web.Models.Entity
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [StringLength(255)]
        [Required]
        public string ImageSource { get; set; }

        [StringLength(50)]
        public string ImageAlt { get; set; }

        [StringLength(50)]
        public string Category { get; set; }
    }
}
