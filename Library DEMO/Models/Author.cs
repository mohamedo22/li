using System.ComponentModel.DataAnnotations;

namespace Library_DEMO.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public List<Book> Books {  get; set; }
        public List<CreditCard> CreditCards {  get; set; }
        public int IdentityCardId { get; set; }
        public IdentityCard IdentityCard {  get; set; }


    }
}
