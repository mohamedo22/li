using Library_DEMO.Data;
using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.DTOs.CreditCardFolder;
using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.DTOs.IdentityCardFolder;
using Library_DEMO.Models;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Repositories.Implementations
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookAuthorGenreDto bookDto)
        {
            Book book = new Book
            {
                Title = bookDto.Title,
                PublishedDate = bookDto.PublishedDate,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookAuthor(BookDto bookDto/*, string name*/)
        {
            //var result = _context.Genres.FirstOrDefault(i => i.Name == name);
            //if (result != null)
            //{
            //    throw new InvalidOperationException($"The following genres already exist: {result}");
            //}

            var existingGenres = _context.Genres.Select(g => g.Name).ToList();
            var uniqueGenres = bookDto.Genres
                                       .Select(i => i.Name)
                                       .Distinct()
                                       .ToList();

            var duplicateGenres = uniqueGenres.Where(ug => existingGenres.Contains(ug)).ToList();
            if (duplicateGenres.Any())
            {
                throw new InvalidOperationException($"The following genres already exist: {string.Join(", ", duplicateGenres)}");
            }

            Book book = new Book
            {
                Title = bookDto.Title,
                PublishedDate = bookDto.PublishedDate,
                Authors = bookDto.Authors.Select(i => new Author
                {
                    Name = i.Name,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    CreditCards = i.CreditCards.Select(i => new CreditCard
                    {
                        Name = i.Name,
                        Type = i.Type
                    }).ToList(),
                    IdentityCard =  new IdentityCard
                    {
                        ExpireDate = i.IdentityCard.ExpireDate,
                    },
                }).ToList(),
                Genres = bookDto.Genres.Select(i => new Genre
                {
                    Name = i.Name
                }).ToList(),
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookAuthorJoining(int bookId, int authorId)
        {
            var book = _context.Books.Include(i => i.Authors).FirstOrDefault(i => i.Id == bookId);
            var author = _context.Authors.FirstOrDefault(i => i.Id == authorId);

            book.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.FirstOrDefault(i => i.Id == bookId);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public BookDto GetBookById(int id)
        {
            var book = _context.Books
                .Include(i => i.Authors)
                .ThenInclude(a => a.CreditCards)
                .Include(i => i.Authors)
                .ThenInclude(a => a.IdentityCard)
                .Include(g => g.Genres)
                .FirstOrDefault(i => i.Id == id);

            if(book != null)
            {
                BookDto bookDto = new BookDto
                {
                    Title = book.Title,
                    PublishedDate = book.PublishedDate,
                    Authors = book.Authors.Select(i => new AuthorBookCreditCardDto
                    {
                        Name = i.Name,
                        Email = i.Email,
                        PhoneNumber = i.PhoneNumber,
                        CreditCards = i.CreditCards.Select(i => new CreditCardAuthorDto
                        {
                            Name = i.Name,
                            Type = i.Type
                        }).ToList(),
                        IdentityCard = new IdentityCardDto
                        {
                            ExpireDate = i.IdentityCard.ExpireDate,
                        }
                    }).ToList(),
                    Genres = book.Genres.Select(i => new GenreBookDto
                    {
                        Name = i.Name,
                    }).ToList()
                };
                return bookDto;
            }
            return null;
        }

        public List<BookDto> GetBooks()
        {
            var result = _context.Books
                .Include(i => i.Authors)
                .ThenInclude(a => a.CreditCards)
                .Include(i => i.Authors)
                .ThenInclude(a => a.IdentityCard)
                .Include(g => g.Genres)
                .Select(i => new BookDto
                {
                    Title = i.Title,
                    PublishedDate = i.PublishedDate,
                    Authors = i.Authors.Select(i => new AuthorBookCreditCardDto
                    {
                        Name = i.Name,
                        Email = i.Email,
                        PhoneNumber = i.PhoneNumber,
                        CreditCards = i.CreditCards.Select(i => new CreditCardAuthorDto
                        {
                            Name = i.Name,
                            Type = i.Type
                        }).ToList(),
                        IdentityCard = new IdentityCardDto
                        {
                            ExpireDate = i.IdentityCard.ExpireDate,
                        }
                    }).ToList(),
                    Genres = i.Genres.Select(i => new GenreBookDto
                    {
                        Name = i.Name,
                    }).ToList()
                }).ToList();
            return result;
        }

        public void UpdateBook(int bookId, BookDto bookDto)
        {
            var book = _context.Books
                .Include(i => i.Authors)
                .ThenInclude(a => a.CreditCards)
                .Include(i => i.Authors)
                .ThenInclude(a => a.IdentityCard)
                .Include(g => g.Genres)
                .FirstOrDefault(i => i.Id == bookId);

            if(book != null)
            {
                book.Title = bookDto.Title;
                book.PublishedDate = bookDto.PublishedDate;
                book.Authors = bookDto.Authors.Select(i => new Author
                {
                    Name = i.Name,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    CreditCards = i.CreditCards.Select(i => new CreditCard
                    {
                        Name = i.Name,
                        Type = i.Type
                    }).ToList(),
                    IdentityCard = new IdentityCard
                    {
                        ExpireDate = i.IdentityCard.ExpireDate
                    }
                }).ToList();
                book.Genres = bookDto.Genres.Select(i => new Genre
                {
                    Name = i.Name
                }).ToList();

                _context.Books.Update(book);
                _context.SaveChanges();
            }
        }
    }
}
