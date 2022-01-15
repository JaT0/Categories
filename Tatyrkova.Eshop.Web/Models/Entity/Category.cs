using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tatyrkova.Eshop.Web.Models.Entity
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
    
}
