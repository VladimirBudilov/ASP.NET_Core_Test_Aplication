using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
