using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.Models;
using System.ComponentModel.DataAnnotations;

namespace Library_DEMO.DTOs.BookFolder
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public List<AuthorBookCreditCardDto> Authors { get; set; }
        public List<GenreBookDto> Genres { get; set; }
    }
}
