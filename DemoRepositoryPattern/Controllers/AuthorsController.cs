using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Dto.Author;
using DemoRepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepositoryPattern.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GellAllAuhors()
        {
            var auhors = _unitOfWork.Authors.GetAll();
            return Ok(auhors);

        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _unitOfWork.Authors.GetById(id);
            return Ok(author);

        }
        [HttpPost]
        public IActionResult CreateAuthor(AddAuthorModel model)
        {
            Author author = new Author
            {
                Name = model.Name,
                Female = model.Female,
                Born = model.Born,
            };
            _unitOfWork.Authors.Add(author);

            _unitOfWork.Save();
            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, Author model)
        {
            Author author = new Author
            {
                Id = id,
                Name = model.Name,
                Female = model.Female,
                Born = model.Born,
            };

            if (id != author.Id)
            {
                return BadRequest();

            }
            _unitOfWork.Authors.Update(author);
            _unitOfWork.Save();
            return Ok();

        }
        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            _unitOfWork.Authors.Delete(id);
            _unitOfWork.Save();
            return Ok();

        }
    }
}
