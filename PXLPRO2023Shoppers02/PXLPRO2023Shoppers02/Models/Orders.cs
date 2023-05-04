using System.ComponentModel.DataAnnotations;

namespace PXLPRO2023Shoppers02.Models
{
    public class Orders
    {
        //ERD is foreign keys
        [Required]
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string? OrderName { get; set; }

        [Required]
        public string? OrderNumber { get; set; }

        [Required]
        public string? OrderDescription { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }
    }
}
