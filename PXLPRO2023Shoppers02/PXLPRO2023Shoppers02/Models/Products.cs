using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLPRO2023Shoppers02.Models
{
    public class Products
    {
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string? ProductName { get; set; }

        [Required]
        [DisplayName("Info")]
        public string? ProductDescription { get; set; }

        [DisplayName("Image")]
        public string? ProductImage { get; set; }

        [Required]
        [DisplayName("Price")]
        public double ProductPrice { get; set; }
        public string? ProductImage { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public ProductsCategories? Category { get; set; }


    }
}
