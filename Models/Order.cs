using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANPDB.Models
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrderNumber { get; set; }   // UNIQUE

        public int? UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string RespName { get; set; }

        [Required]
        [MaxLength(20)]
        public string RespPhone { get; set; }

        [MaxLength(255)]
        public string? RespEmail { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        [MaxLength(255)]
        public string? InvoiceFile { get; set; }

        [MaxLength(50)]
        public string? PaymentMethod { get; set; } // COD, Bkash, Card

        public bool IsPaid { get; set; } = false;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ExtraCharge { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal PaidAmount { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal DueAmount { get; set; } = 0;

        [MaxLength(100)]
        public string Status { get; set; } = "pending";

        [MaxLength(255)]
        public string? ReminderNote { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
