using Library_DEMO.Data;
using Library_DEMO.DTOs.IdentityCardFolder;
using Library_DEMO.Models;
using Library_DEMO.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_DEMO.Repositories.Implementations
{
    public class IdentityCardRepo : IIdentityCardRepo
    {
        private readonly AppDbContext _context;

        public IdentityCardRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddIdentityCardAuthor(IdentityCardDto identityCardDto)
        {
            IdentityCard identityCard = new IdentityCard
            {
                ExpireDate = identityCardDto.ExpireDate,
            };
            _context.IdentityCards.Add(identityCard);
            _context.SaveChanges();
        }

        public List<IdentityCardDto> GetAllIdentityCard()
        {
            var result = _context.IdentityCards
                .Include(a => a.Author)
                .Select(i => new IdentityCardDto
                {
                    ExpireDate = i.ExpireDate,
                }).ToList();
            return result;
        }

        public IdentityCardDto GetIdentityCardById(int id)
        {
            var result = _context.IdentityCards
                .Include(a => a.Author)
                .FirstOrDefault(i => i.Id == id);

            if (result != null)
            {
                IdentityCardDto identityCardDto = new IdentityCardDto
                {
                    ExpireDate = result.ExpireDate,
                };
                return identityCardDto;
            }
            return null;
        }

        public void RemoveIdentityCard(int id)
        {
            var identityCard = _context.IdentityCards.FirstOrDefault(i => i.Id == id);
            _context.IdentityCards.Remove(identityCard);
            _context.SaveChanges();
        }

        public void UpdateIdentityCardAuthor(int id, IdentityCardDto identityCardDto)
        {
            var identityCard = _context.IdentityCards.Include(a => a.Author).FirstOrDefault(i => i.Id == id);
            if (identityCardDto != null)
            {
                identityCard.ExpireDate = identityCardDto.ExpireDate;
                _context.IdentityCards.Update(identityCard);
                _context.SaveChanges();
            }   
        }
    }
}
