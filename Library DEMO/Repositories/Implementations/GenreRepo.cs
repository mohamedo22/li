using Library_DEMO.Data;
using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.Models;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Repositories.Implementations
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AppDbContext _context;

        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddGenre(GenreBookDto genreDto)
        {
            Genre genre = new Genre
            {
                Name = genreDto.Name,
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void AddGenreBook(GenreDto genreDto)
        {
            Genre genre = new Genre
            {
                Name = genreDto.Name,
                Books = genreDto.Books.Select(i => new Book
                {
                    Title = i.Title,
                    PublishedDate = i.PublishedDate,
                }).ToList(),
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void AddGenreBookJoining(int genreId, int bookId)
        {
            var genre = _context.Genres.Include(b => b.Books).FirstOrDefault(i => i.Id == genreId);
            var book = _context.Books.FirstOrDefault(i => i.Id == bookId);

            genre.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteGenre(int id)
        {
            var genre = _context.Genres.FirstOrDefault(i => i.Id == id);
            if(genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }

        public List<GenreDto> GetAllGenreBooks()
        {
            var result = _context.Genres
                .Include(b => b.Books)
                .Select(i => new GenreDto
                {
                    Name = i.Name,
                    Books = i.Books.Select(i => new BookAuthorGenreDto
                    {
                        Title = i.Title,
                        PublishedDate = i.PublishedDate,
                    }).ToList(),
                }).ToList();
            return result;
        }

        public GenreDto GetGenreById(int id)
        {
            var genre = _context.Genres
                .Include(b => b.Books)
                .FirstOrDefault(i => i.Id == id);

            if(genre != null )
            {
                GenreDto genreDto = new GenreDto
                {
                    Name = genre.Name,
                    Books = genre.Books.Select(i => new BookAuthorGenreDto
                    {
                        Title = i.Title,
                        PublishedDate = i.PublishedDate,
                    }).ToList()
                };
                return genreDto;
            }
            return null;
        }

        public void UpdateGenre(int id,GenreDto genreDto)
        {
            var genre = _context.Genres
                .Include(b => b.Books)
                .FirstOrDefault(i => i.Id == id);
            if(genre != null )
            {
                genre.Name = genreDto.Name;
                genre.Books = genreDto.Books.Select(i => new Book
                {
                    Title = i.Title,
                    PublishedDate = i.PublishedDate,
                }).ToList();
                _context.Genres.Update(genre);
                _context.SaveChanges();
            }
        }
    }
}
