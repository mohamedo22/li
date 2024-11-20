using Library_DEMO.DTOs.BookFolder;
using Library_DEMO.Models;

namespace Library_DEMO.DTOs.GenreFolder
{
    public class GenreDto
    {
        public string Name { get; set; }
        public List<BookAuthorGenreDto> Books { get; set; }
    }
}
