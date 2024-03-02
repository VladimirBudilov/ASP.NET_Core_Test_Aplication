using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        [Column("category_id")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
