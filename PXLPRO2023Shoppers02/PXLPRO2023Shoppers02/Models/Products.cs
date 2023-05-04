using System.ComponentModel.DataAnnotations;

namespace PXLPRO2023Shoppers02.Models
{
    public class Products
    {
        [Required]
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? ProductDescription { get; set; }

        [Required]
        public double ProductPrice { get; set; }


    }
}
