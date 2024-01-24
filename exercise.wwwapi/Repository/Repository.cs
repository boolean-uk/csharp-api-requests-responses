using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private BooksCollection _books;
        private StudentCollection _students;
        private LanguageCollection _languages;

        public Repository(BooksCollection books, StudentCollection students, LanguageCollection lanuages) 
        { 
            _books = books;
            _students = students;
            _languages = lanuages;
        }

        public Book CreateBook(BookPut book)
        {
            return _books.CreateBook(book);
        }

        public Language CreateLanguage(string language)
        {
            return _languages.CreateLanguage(language);
        }

        public void CreateStudent(Student student)
        {
            _students.Add(student);
        }

        public Book FindBook(int id)
        {
            return _books.GetBookById(id);
        }

        public Language FindLanguage(string language)
        {
            return _languages.GetLanguageByName(language);
        }

        public Student FindStudent(string firstName)
        {
            return _students.getByFirstName(firstName);
        }

        public List<Book> GetAllBooks()
        {
            return _books.GetAllBooks();
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return _languages.GetAllLanguages();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Book removeBook(int id)
        {
            return _books.DeleteBook(id);
        }

        public Language removeLanguage(string name)
        {
            return _languages.DeleteLanguage(name);
        }

        public Student removeStudent(string firstName)
        {
            return _students.DeleteStudent(firstName);
        }

        public Language updateLanguage(Language language, string name)
        {
            language.Update(name);
            return language;
        }
    }
}
