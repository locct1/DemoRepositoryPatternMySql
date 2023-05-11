using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoRepositoryPattern.Data
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public bool Female { get; set; }
        public int Born { get; set; }
    }
}
