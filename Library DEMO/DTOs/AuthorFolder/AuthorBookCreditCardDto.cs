using Library_DEMO.DTOs.CreditCardFolder;
using Library_DEMO.DTOs.IdentityCardFolder;
using System.ComponentModel.DataAnnotations;

namespace Library_DEMO.DTOs.AuthorFolder
{
    public class AuthorBookCreditCardDto
    {
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public List<CreditCardAuthorDto> CreditCards { get; set; }
        public IdentityCardDto IdentityCard { get; set; } = new IdentityCardDto();
    }
}
