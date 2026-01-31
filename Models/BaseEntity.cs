namespace ANPDB.Models
{
    public class BaseEntity
    {
        public string? createBy { get; set; }
        public string? updateBy { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updateAt { get; set; }
        public bool softDelete { get; set; }
    }
}
