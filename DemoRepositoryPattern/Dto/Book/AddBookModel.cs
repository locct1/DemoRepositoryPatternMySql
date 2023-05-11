using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DemoRepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Dto.Book
{
    public class AddBookModel
    {
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
