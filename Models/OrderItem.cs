using System.ComponentModel.DataAnnotations.Schema;

namespace ANPDB.Models
{
    public class OrderItem : BaseEntity
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; } = 1;

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalUnitPrice { get; set; } = 0;
    }
}
