using Library_DEMO.DTOs.AuthorFolder;
using Library_DEMO.DTOs.BookFolder;

namespace Library_DEMO.Repositories.Interfaces
{
    public interface IAuthorRepo
    {
        public void AddAuthor(AuthorBookCreditCardDto authorDto);
        public void AddAuthorBook(AuthorDto authorDto);
        public void AddAuthorBookJoining(int authorId, int bookId);
        public List<AuthorDto> GetAllAuthorBooks();
        public AuthorDto GetAuthorBooksId(int id);
        public void UpdateAuthorBook(int authorId, AuthorDto authorDto);
        public void DeleteAuthorBook(int authorId);
    }
}
