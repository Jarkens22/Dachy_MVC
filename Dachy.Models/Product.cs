using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dachy.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Producent { get; set; }
        [Required]
        [Display(Name = "Cena katalogowa")]
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Cena przy zakupie 100+ sztuk")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        [Required]
        [Display(Name = "Cena przy zakupie 300+ sztuk")]
        [Range(1, 1000)]
        public double Price300 { get; set; }
        [Required]
        [Display(Name = "Cena przy zakupie 500+ sztuk")]
        [Range(1, 1000)]
        public double Price500 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }


    }
}
