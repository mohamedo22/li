using Library_DEMO.DTOs.IdentityCardFolder;

namespace Library_DEMO.Repositories.Interfaces
{
    public interface IIdentityCardRepo
    {
        public void AddIdentityCardAuthor(IdentityCardDto identityCardDto);
        public List<IdentityCardDto> GetAllIdentityCard();
        public IdentityCardDto GetIdentityCardById(int id);
        public void UpdateIdentityCardAuthor(int id,IdentityCardDto identityCardDto);
        public void RemoveIdentityCard(int id);
    }
}
