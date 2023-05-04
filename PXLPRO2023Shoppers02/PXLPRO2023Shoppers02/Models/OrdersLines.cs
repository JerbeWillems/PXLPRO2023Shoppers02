using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PXLPRO2023Shoppers02.Models
{
    public class OrdersLines
    {
        [Required]
        [Key]
        public int OrderLineId { get; set; }

        [Required]
        public string? OrderLineNumber { get; set; }
        
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [ValidateNever]
        public Orders? Order { get; set; }
        
        
    }
}
