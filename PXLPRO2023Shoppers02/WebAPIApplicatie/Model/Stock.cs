using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebAPIApplicatie.Model
{
    public class Stock
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

        [Required]
        [DisplayName("Total")]
        public double ProductTotal { get; set; }


    }
}
