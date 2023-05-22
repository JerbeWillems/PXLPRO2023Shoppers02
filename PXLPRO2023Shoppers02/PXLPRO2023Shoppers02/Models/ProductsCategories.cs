using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLPRO2023Shoppers02.Models
{
    public class ProductsCategories
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        [Required]
        public string? CategoryDescription { get; set; }
        
    }
}
