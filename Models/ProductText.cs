using System.ComponentModel.DataAnnotations;

namespace ANPDB.Models
{
    public class ProductText
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [MaxLength(255)]
        public string? Keywords { get; set; }

        public string? Description { get; set; }

        [MaxLength(255)]
        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? Features { get; set; }

        public string? Specifications { get; set; }

        public string? AdditionalInfo { get; set; }

        [MaxLength(255)]
        public string? Image1 { get; set; }

        [MaxLength(255)]
        public string? Image2 { get; set; }

        [MaxLength(255)]
        public string? Image3 { get; set; }

        [MaxLength(10)]
        public string Language { get; set; } = "en";
    }
}
