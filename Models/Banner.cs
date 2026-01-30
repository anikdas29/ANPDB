using System.ComponentModel.DataAnnotations;

namespace ANPDB.Models
{
    public class Banner
    {
        public int Id { get; set; }

        // 🔗 Optional Category relation
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(55)]
        public string? Image { get; set; }

        [MaxLength(55)]
        public string? Image1 { get; set; }

        [MaxLength(55)]
        public string? Image2 { get; set; }

        [MaxLength(55)]
        public string? Image3 { get; set; }

        [MaxLength(255)]
        public string? Link { get; set; }

        public bool Status { get; set; } = true;
    }
}
