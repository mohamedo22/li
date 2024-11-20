using Library_DEMO.Data;
using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.DTOs.CreditCardFolder;
using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.DTOs.IdentityCardFolder;
using Library_DEMO.Models;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Repositories.Implementations
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;

        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorBookCreditCardDto authorDto)
        {
            Author author = new Author
            {
                Name = authorDto.Name,
                Email = authorDto.Email,
                PhoneNumber = authorDto.PhoneNumber,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddAuthorBook(AuthorDto authorDto)
        {
            Author author = new Author
            {
                Name = authorDto.Name,
                Email = authorDto.Email,
                PhoneNumber = authorDto.PhoneNumber,
                Books = authorDto.Books.Select(i => new Book
                {
                    Title = i.Title,
                    PublishedDate = i.PublishedDate,
                    Genres = i.Genres.Select(i => new Genre
                    {
                        Name = i.Name
                    }).ToList()
                }).ToList(),
                CreditCards = authorDto.CreditCards.Select(i => new CreditCard
                {
                    Name= i.Name,
                    Type = i.Type,
                }).ToList(),
                IdentityCard = new IdentityCard
                {
                    ExpireDate = authorDto.IdentityCard.ExpireDate,
                }
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddAuthorBookJoining(int authorId, int bookId)
        {
            var author = _context.Authors.Include(i => i.Books).FirstOrDefault(i => i.Id == authorId);
            var book = _context.Books.FirstOrDefault(i => i.Id == bookId);

            author.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteAuthorBook(int authorId)
        {
            var author = _context.Authors.FirstOrDefault(i => i.Id == authorId);
            if(author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
        public List<AuthorDto> GetAllAuthorBooks()
        {
            var result = _context.Authors
                .Include(b => b.Books)
                .ThenInclude(g => g.Genres)
                .Include(c => c.CreditCards)
                .Include(id => id.IdentityCard)
                .Select(i => new AuthorDto
                {
                    Name = i.Name,
                    Email = i.Email,
                    PhoneNumber = i.PhoneNumber,
                    Books = i.Books.Select(i => new BookAuthorGenreDto
                    {
                        Title = i.Title,
                        PublishedDate = i.PublishedDate,
                        Genres = i.Genres.Select(i => new GenreBookDto
                        {
                            Name = i.Name
                        }).ToList()
                    }).ToList(),
                    CreditCards = i.CreditCards.Select(cc => new CreditCardAuthorDto
                    {
                        Name = cc.Name,
                        Type = cc.Type 
                    }).ToList(),
                    IdentityCard = new IdentityCardDto
                    {
                        ExpireDate = i.IdentityCard.ExpireDate,
                    } 
                }).ToList();
            if (result != null)
                return result;
            return null;
        }

        public AuthorDto GetAuthorBooksId(int id)
        {
            var author = _context.Authors
                .Include(i => i.Books)
                .ThenInclude(i => i.Genres)
                .Include(i => i.CreditCards)
                .Include(i => i.IdentityCard)
                .FirstOrDefault(i => i.Id == id);

            if(author != null)
            {
                AuthorDto authorDto = new AuthorDto
                {
                    Name = author.Name,
                    Email = author.Email,
                    PhoneNumber = author.PhoneNumber,
                    Books = author.Books.Select(i => new BookAuthorGenreDto
                    {
                        Title = i.Title,
                        PublishedDate = i.PublishedDate,
                        Genres = i.Genres.Select(i => new GenreBookDto
                        {
                            Name = i.Name
                        }).ToList(),
                    }).ToList(),
                    CreditCards = author.CreditCards.Select(cc => new CreditCardAuthorDto
                    {
                        Name = cc.Name,
                        Type = cc.Type 
                    }).ToList(),
                    IdentityCard =  new IdentityCardDto
                    {
                        ExpireDate = author.IdentityCard.ExpireDate,
                    }
                };
                return authorDto;
            }
            return null;
        }

        public void UpdateAuthorBook([FromBody]int authorId, AuthorDto authorDto)
        {
            var author = _context.Authors
                .Include(b => b.Books)
                .ThenInclude(g => g.Genres)
                .Include(c => c.CreditCards)
                .Include(i => i.IdentityCard)
                .FirstOrDefault(i => i.Id == authorId);

            if(author != null)
            {
                author.Name = authorDto.Name;
                author.Email = authorDto.Email;
                author.PhoneNumber = authorDto.PhoneNumber;
                author.Books = authorDto.Books.Select(i => new Book
                {
                    Title = i.Title,
                    PublishedDate = i.PublishedDate,
                    Genres = i.Genres.Select(i => new Genre
                    {
                        Name = i.Name,
                    }).ToList()
                }).ToList();
                author.CreditCards = authorDto.CreditCards.Select(i => new CreditCard
                {
                    Name = i.Name,
                    Type = i.Type,
                }).ToList();
                author.IdentityCard = new IdentityCard
                {
                    ExpireDate = authorDto.IdentityCard.ExpireDate,
                };

                _context.Authors.Update(author);
                _context.SaveChanges();
            }
        }
    }
}
