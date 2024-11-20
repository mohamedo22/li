using Library_DEMO.Data;
using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.DTOs.CreditCardFolder;
using Library_DEMO.Models;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Repositories.Implementations
{
    public class CreditCardRepo : ICreditCardRepo
    {
        private readonly AppDbContext _context;

        public CreditCardRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddCreditCardAuthor(CreditCardDto creditCardDto)
        {
            CreditCard creditCard = new CreditCard
            {
                Name = creditCardDto.Name,
                Type = creditCardDto.Type,
                Author = new Author
                {
                    Name = creditCardDto.Author.Name,
                    Email = creditCardDto.Author.Email,
                    PhoneNumber = creditCardDto.Author.PhoneNumber,
                    Books = creditCardDto.Author.Books.Select(i => new Book
                    {
                        Title = i.Title,
                        PublishedDate = i.PublishedDate,
                    }).ToList()
                }
            };
            _context.CreditCards.Add(creditCard);
            _context.SaveChanges();
        }
        public void DeleteCreditCard(int id)
        {
            var card = _context.CreditCards.FirstOrDefault(i => i.Id == id);
            if(card != null)
            {
                _context.CreditCards.Remove(card);
                _context.SaveChanges();
            }
        }

        public CreditCardDto GetCreditCardById(int id)
        {
            var card = _context.CreditCards
                .Include(i => i.Author)
                .FirstOrDefault(i => i.Id == id);
            if(card != null)
            {
                CreditCardDto creditCardDto = new CreditCardDto
                {
                    Name = card.Name,
                    Type = card.Type,
                    Author = new AuthorDto
                    {
                        Name = card.Author.Name,
                        Email = card.Author.Email,
                        PhoneNumber = card.Author.PhoneNumber,
                        Books = card.Author.Books.Select(i => new BookAuthorGenreDto
                        {
                            Title = i.Title,
                            PublishedDate = i.PublishedDate,

                        }).ToList()
                    },
                };
                return creditCardDto;
            }
            return null;
        }

        public List<CreditCardDto> GetCreditCards()
        {
            var result = _context.CreditCards
                .Include(a => a.Author)
                .Select(card => new CreditCardDto
                {
                    Name = card.Name,
                    Type = card.Type,
                    Author = new AuthorDto
                    {
                        Name = card.Author.Name,
                        Email = card.Author.Email,
                        PhoneNumber = card.Author.PhoneNumber,
                        Books = card.Author.Books.Select(i => new BookAuthorGenreDto
                        {
                            Title = i.Title,
                            PublishedDate = i.PublishedDate,

                        }).ToList()
                    },
                }).ToList();
            return result;
        }

        public void UpdateCreditCard(int id, CreditCardDto creditCardDto)
        {
            var creditCard = _context.CreditCards
                .Include(a => a.Author)
                .FirstOrDefault(i => i.Id == id);
            if(creditCard != null)
            {
                creditCard.Name = creditCardDto.Name;
                creditCard.Type = creditCardDto.Type;
                creditCard.Author = new Author
                {
                    Name = creditCardDto.Author.Name,
                    Email = creditCardDto.Author.Email,
                    PhoneNumber = creditCardDto.Author.PhoneNumber,
                };
                _context.CreditCards.Update(creditCard);
                _context.SaveChanges();
            }
        }
    }
}
