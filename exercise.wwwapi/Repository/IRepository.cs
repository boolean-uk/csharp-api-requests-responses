using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public IEnumerable<Student> GetAllStudents();

        public void CreateStudent(Student student);

        public Student FindStudent(string firstName);

        public Student removeStudent(string firstName);

        public IEnumerable<Language> GetAllLanguages();

        public Language CreateLanguage(string language);

        public Language FindLanguage(string language);

        public Language removeLanguage(string language);

        public Language updateLanguage(Language language, string name);
        public List<Book> GetAllBooks();
        public Book CreateBook(BookPut book);
        public Book FindBook(int id);
        public Book removeBook(int id);
    }
}
