using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private StudentCollection _studentCollection;
        private LanguageCollection _languageCollection;
        private BookCollection _bookCollection;

        public Repository(StudentCollection studentCollection, LanguageCollection languageCollection, BookCollection bookCollection)
        {
            _studentCollection = studentCollection;
            _languageCollection = languageCollection;
            _bookCollection = bookCollection;
        }


        // --STUDENTS--
        public Student GetStudent(string searchInput)
        {
            return _studentCollection.Get(searchInput);
        }
        public IEnumerable<Student> GetStudents()
        {
            return _studentCollection.GetAll();
        }
        public Student CreateStudent(Student student)
        {
            return _studentCollection.Create(student);
        }
        public Student UpdateStudent(string studentName, string firstName)
        {
            return _studentCollection.Update(studentName, firstName);
        }

        public bool DeleteStudent(string studentName)
        {
            return _studentCollection.Delete(studentName);
        }


        // --LANGUAGES--

        public IEnumerable<Language> GetLanguages()
        {
            return _languageCollection.GetAll();
        }
        public Language GetLanguage(string language)
        {
            return _languageCollection.Get(language);
        }
        public Language CreateLanguage(Language language)
        {
            return _languageCollection.Create(language);
        }

        public Language UpdateLanguage(string language, string newLanguage)
        {
            return _languageCollection.Update(language, newLanguage);
        }

        public bool DeleteLanguage(string language)
        {
            return _languageCollection.Delete(language);
        }


        // --BOOKS--
        public IEnumerable<Book> GetBooks()
        {
            return _bookCollection.GetAll();
        }

        public Book GetBook(int id)
        {
            return _bookCollection.Get(id);
        }

        public Book CreateBook(Book book)
        {
            return _bookCollection.Create(book);
        }

        public Book UpdateBook(int id, Book newBook)
        {
            return _bookCollection.Update(id, newBook);
        }

        public bool DeleteBook(int id)
        {
            return _bookCollection.Delete(id);
        }
    }
}
