using Library_DEMO.DTOs.BookFolder;

namespace Library_DEMO.Repositories.Interfaces
{
    public interface IBookRepo
    {
        public void AddBook(BookAuthorGenreDto bookDto);
        public void AddBookAuthor(BookDto bookDto/*,string name*/);
        public void AddBookAuthorJoining(int bookId, int authorId);
        public List<BookDto> GetBooks();
        public BookDto GetBookById(int id);
        public void UpdateBook(int bookId, BookDto bookDto);
        public void DeleteBook(int bookId);
    }
}
