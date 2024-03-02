using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Models
{
    [Table("categories")]
    public class Category : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}
