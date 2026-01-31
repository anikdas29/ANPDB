using System.ComponentModel.DataAnnotations;

namespace ANPDB.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string ShowUrl { get; set; }   // UNIQUE

        public string? Description { get; set; }

        [MaxLength(255)]
        public string? Image { get; set; }

        public int SubCategory { get; set; } = 0;

        [MaxLength(255)]
        public string? MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaKeywords { get; set; }

        public bool Status { get; set; } = true;
    }
}
