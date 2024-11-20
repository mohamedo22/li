using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_DEMO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }
        [HttpPost("Author")]
        public IActionResult AddAuthor(AuthorBookCreditCardDto authorDto)
        {
            _authorRepo.AddAuthor(authorDto);
            return Ok();
        }
        [HttpPost("Author-Book")]
        public IActionResult AddAuthorBook([FromBody] AuthorDto authorDto)
        {
            _authorRepo.AddAuthorBook(authorDto);
            return Ok();
        }
        [HttpPost("Author-Book-Joining")]
        public IActionResult AddAuthorBookJoining(int authorId, int bookId)
        {
            _authorRepo.AddAuthorBookJoining(authorId, bookId);
            return Ok();
        }
        [HttpGet("Get-Authors-Books")]
        public IActionResult GetAuthorBook()
        {
            var result = _authorRepo.GetAllAuthorBooks();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorBookById(int id)
        {
            var result = _authorRepo.GetAuthorBooksId(id);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult PutAuthorBook(int id, [FromBody] AuthorDto authorDto)
        {
            _authorRepo.UpdateAuthorBook(id, authorDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthorBook(int id)
        {
            _authorRepo.DeleteAuthorBook(id);
            return Ok();
        }
    }
}
