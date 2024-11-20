using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_DEMO.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Published Date")]
        public DateTime PublishedDate { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
