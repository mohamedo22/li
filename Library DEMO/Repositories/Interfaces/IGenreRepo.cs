using Library_DEMO.DTOs.GenreFolder;

namespace Library_DEMO.Repositories.Interfaces
{
    public interface IGenreRepo
    {
        public List<GenreDto> GetAllGenreBooks();
        public GenreDto GetGenreById(int id);
        public void AddGenre(GenreBookDto genreDto);
        public void AddGenreBook(GenreDto genreDto);
        public void AddGenreBookJoining(int genreId, int bookId);
        public void UpdateGenre(int id,GenreDto genreDto);
        public void DeleteGenre(int id);
    }
}
