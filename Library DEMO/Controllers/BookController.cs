using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_DEMO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepo _bookRepo;

        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        [HttpPost("Add-Book")]
        public IActionResult AddBook(BookAuthorGenreDto bookDto)
        {
            _bookRepo.AddBook(bookDto);
            return Ok();
        }
        [HttpPost("Add-Book-Author")]
        public IActionResult AddBookAuthor(BookDto bookDto/*,string name*/)
        {
            _bookRepo.AddBookAuthor(bookDto/*,name*/);
            return Ok();
        }     
        [HttpPost("Add-Book-Author-Joininig")]
        public IActionResult AddBookAuthorJoining(int bookId,int authorId)
        {
            _bookRepo.AddBookAuthorJoining(bookId,authorId);
            return Ok();
        }
        [HttpGet("Book-Author")]
        public IActionResult GetBooks()
        {
            var books = _bookRepo.GetBooks(); 
            return Ok(books);
        }
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookRepo.GetBookById(id);
            return Ok(book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,BookDto bookDto)
        {
            _bookRepo.UpdateBook(id,bookDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepo.DeleteBook(id);
            return Ok();
        }
    }
}
