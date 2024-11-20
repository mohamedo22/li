using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_DEMO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly IGenreRepo _genreRepo;

        public GenreController(IGenreRepo genreRepo)
        {
            _genreRepo = genreRepo;
        }
        [HttpPost("Add-Genre")]
        public IActionResult AddGenre(GenreBookDto genreDto)
        {
            _genreRepo.AddGenre(genreDto);
            return Ok();
        }
        [HttpPost("Add-Genre-Book")]
        public IActionResult AddGenreBook(GenreDto genreDto)
        {
            _genreRepo.AddGenreBook(genreDto);
            return Ok();
        }
        [HttpPost("Add-Genre-Book-Joining")]
        public IActionResult AddGenreBookJoining(int genreId,int bookId)
        {
            _genreRepo.AddGenreBookJoining(genreId,bookId);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetGenreBookById(int id)
        {
            var genre = _genreRepo.GetGenreById(id);
            if (genre != null)
                return Ok(genre);
            return BadRequest();
        }
        [HttpGet("Get-Genre-Books")]
        public IActionResult GetGenreBooks()
        {
            var genres = _genreRepo.GetAllGenreBooks();
            if (genres != null)
                return Ok(genres);
            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id,GenreDto genreDto)
        {
            _genreRepo.UpdateGenre(id,genreDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            _genreRepo.DeleteGenre(id);
            return Ok();
        }
    }
}
