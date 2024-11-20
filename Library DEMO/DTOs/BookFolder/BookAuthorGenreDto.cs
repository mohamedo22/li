using Library_DEMO.DTOs.GenreFolder;
using Library_DEMO.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_DEMO.DTOs.BookFolder
{
    public class BookAuthorGenreDto
    {
        public string Title { get; set; }
        [DisplayName("Published Date")]
        public DateTime PublishedDate { get; set; }
        public List<GenreBookDto> Genres { get; set; }
    }
}
