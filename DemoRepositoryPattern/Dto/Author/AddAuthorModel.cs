using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Author
{
    public class AddAuthorModel
    {

        [MaxLength(255)]
        public string Name { get; set; }
        public bool Female { get; set; }
        public int Born { get; set; }
    }
}
