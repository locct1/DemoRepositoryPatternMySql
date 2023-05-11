using System.ComponentModel.DataAnnotations;

namespace DemoRepositoryPattern.Dto.Book
{
    public class UpdateBookModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Topic { get; set; }
        [Required]
        public int PublishYear { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public double Price { set; get; }
        [Required]
        public Byte Rating { get; set; }
    }
}
