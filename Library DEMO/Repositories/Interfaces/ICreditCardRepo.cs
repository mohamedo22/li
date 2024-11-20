using Library_DEMO.DTOs.CreditCardFolder;

namespace Library_DEMO.Repositories.Interfaces
{
    public interface ICreditCardRepo
    {
        public void AddCreditCardAuthor(CreditCardDto creditCardDto);
        public List<CreditCardDto> GetCreditCards();
        public CreditCardDto GetCreditCardById(int id);
        public void UpdateCreditCard(int id,CreditCardDto creditCardDto);
        public void DeleteCreditCard(int id);
    }
}
