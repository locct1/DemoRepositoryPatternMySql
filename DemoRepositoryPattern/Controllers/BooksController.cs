using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Book;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GellAllBooks()
        {
            //var books = _unitOfWork.Books.GetAll(book => book.Name == "Iphone 13", includeProperties: "Author");
            //var books = _unitOfWork.Books.GetAll(orderBy: q => q.OrderBy(p => p.Price), includeProperties: "Author");
            var books = _unitOfWork.Books.GetAll(includeProperties: "Author");
            return Ok(books);

        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _unitOfWork.Books.GetById(id);
            return Ok(book);

        }
        [HttpPost]
        public IActionResult CreateBook(AddBookModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Topic = model.Topic,
                PublishYear = model.PublishYear,
                AuthorId = model.AuthorId,
                Price = model.Price,
                Rating = model.Rating,

            };
            _unitOfWork.Books.Add(book);
            _unitOfWork.Save();
            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateBook(int id, UpdateBookModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();

            }
            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Topic = model.Topic,
                PublishYear = model.PublishYear,
                AuthorId = model.AuthorId,
                Price = model.Price,
                Rating = model.Rating,
            };
            _unitOfWork.Books.Update(book);
            _unitOfWork.Save();
            return Ok();

        }
        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            _unitOfWork.Books.Delete(id);
            _unitOfWork.Save();
            return Ok();

        }
    }
}
