using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.Models;

namespace Library_DEMO.DTOs.CreditCardFolder
{
    public class CreditCardDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public AuthorDto Author { get; set; }
    }
}
