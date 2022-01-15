using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tatyrkova.Eshop.Web.Models.Validation;

namespace Tatyrkova.Eshop.Web.Models.Entity
{
    [Table(nameof(CarouselItem))]
    public class CarouselItem
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [ContentType("image")]
        [NotMapped]
        public IFormFile Image { get; set; }

        [StringLength(255)]
        [Required]
        public string ImageSource { get; set; }

        [StringLength(50)]
        public string ImageAlt { get; set; }

    }
}
