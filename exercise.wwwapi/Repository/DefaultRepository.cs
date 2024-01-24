using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class DefaultRepository : IRepository
    {
        private StudentCollection _studentCollection;
        private LanguageCollection _languageCollection;
        private BookCollection _bookCollection;

        public DefaultRepository(LanguageCollection langCollection, StudentCollection studCollection, BookCollection bookCollection) 
        {
            _languageCollection = langCollection;
            _studentCollection = studCollection;
            _bookCollection = bookCollection;
        }

        public IEnumerable<Student> GetStudents() 
        {
            return _studentCollection.getAll();
        }

        public Student GetStudentByFirstName(string firstName)
        {
            return _studentCollection.getAll().Where(s => s.FirstName == firstName).FirstOrDefault();
        }

        public Student PostStudent(string firstName, string lastName) 
        {
            Student student = new Student() {  FirstName = firstName, LastName = lastName };
            _studentCollection.Add(student);
            return student;
        }

        public Student UpdateStudentByFirstName(string firstName, string newFirstName, string newLastName)
        {
            Student? student = _studentCollection.getAll().Where(s => s.FirstName == firstName).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            else 
            {
                student.FirstName = newFirstName;
                student.LastName = newLastName;
                return student;
            }

        }

        public Student DeleteStudentByFirstName(string firstName) 
        {
            Student? student = _studentCollection.getAll().Where(s => s.FirstName == firstName).FirstOrDefault();
            if (student != null)
            {
                _studentCollection.Delete(student);
            }                
            return student;
        }

        public Language PostLanguage(string languageName)
        {
            Language lang = new Language(languageName);
            _languageCollection.AddLanguage(lang);
            return lang;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languageCollection.GetLanguages();
        }

        public Language GetSpecificLanguage(string languageName)
        {
            return _languageCollection.GetLanguages().Where(l => l.Name == languageName).FirstOrDefault();
        }

        public Language UpdateLanguageName(string languageName, string newLanguageName)
        {
            Language? lang = _languageCollection.GetLanguages().Where(l => l.Name == languageName).FirstOrDefault();
            if (lang == null)
            {
                return lang;
            }
            else 
            {
                lang.Name = newLanguageName;
                return lang;
            }
        }

        public Language DeleteLanguage(string languageName)
        {
            Language? lang = _languageCollection.GetLanguages().Where(l => l.Name == languageName).FirstOrDefault();
            if (lang != null)
            {
                _languageCollection.RemoveLanguage(lang);
            }
            return lang;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookCollection.GetAllBooks();
        }

        public Book GetSpecificBook(int id)
        {
            return _bookCollection.GetAllBooks().Where(b => b.Id == id).FirstOrDefault();
        }

        public Book AddNewBook(BookDraft newBook)
        {
            return _bookCollection.AddBook(newBook);
        }

        public Book UpdateBook(int id, BookDraft updatedBook)
        {
            Book? book = _bookCollection.GetAllBooks().Where(b => b.Id == id).FirstOrDefault();
            if (book == null || !_bookCollection.validateBook(updatedBook))
            {
                return null;
            }
            else
            {
                book.Title = updatedBook.Title;
                book.numPages = updatedBook.NumPages;
                book.author = updatedBook.Author;
                book.genre = updatedBook.Genre;

                return book;
            }
        }

        public Book RemoveBook(int id)
        {
            Book? book = _bookCollection.GetAllBooks().Where(b => b.Id == id).FirstOrDefault();
            if (book != null)
            {
                return _bookCollection.RemoveBook(book);
            }
            else 
            {
                return book;
            }
        }
    }
}
