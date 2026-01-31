using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANPDB.Models
{
    public class Product : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Slug { get; set; }   // UNIQUE

        [MaxLength(255)]
        public string? Image { get; set; }

        [MaxLength(100)]
        public string? Brand { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal BuyPrice { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal SellPrice { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal OfferPrice { get; set; } = 0;

        [MaxLength(55)]
        public string? Unit { get; set; }

        public int Stock { get; set; } = 0;

        [MaxLength(55)]
        public string? Colour { get; set; }

        [MaxLength(55)]
        public string? Size { get; set; }

        [MaxLength(100)]
        public string? Author { get; set; }

        public bool Status { get; set; } = true;
    }
}
