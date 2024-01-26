using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    //Repository implements IRepository Interface
    public class Repository : IRepository
    {
        private DataCollection _dataCollection;

        public Repository(DataCollection dataCollection)
        {
            _dataCollection = dataCollection;
        }

        public Student AddStudent(Student student)
        {
            return _dataCollection.AddStudent(student);
        }

        public Student DeleteStudent(string firstName)
        {
            return _dataCollection.DeleteStudent(firstName);
         }

        public Student GetStudent(string firstName)
        {
            return _dataCollection.GetStudent(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dataCollection.GetStudents();
        }

        public Student UpdateStudent(string firstName, Student updatedStudent)
        {
            return _dataCollection.UpdateStudent(firstName, updatedStudent);
        }

        /*-------------------Language----------------------------*/

        public Language GetLanguage(string name)
        {
            return _dataCollection.GetLanguage(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _dataCollection.GetLanguages();
        }
        public Language AddLanguage(Language language)
        {
            return _dataCollection.AddLanguage(language);
        }

        public Language UpdateLanguage(string name, Language updatedLanguage)
        {
            return _dataCollection.UpdateLanguage(name, updatedLanguage);
        }

        public Language DeleteLanguage(string name)
        {
            return _dataCollection.DeleteLanguage(name);
        }

        /*-------------------Book------------------------------*/

        public IEnumerable<Book> GetBooks()
        {
            return _dataCollection.GetBooks();
        }

        public Book AddBook(Book book)
        {
            return _dataCollection.AddBook(book);
        }

        public Book GetBook(int id)
        {
            return _dataCollection.GetBook(id);
        }

        public Book UpdateBook(int id, Book updatedBook)
        {
            return _dataCollection.UpdateBook(id, updatedBook);
        }

        public Book DeleteBook(int id)
        {
            return _dataCollection.DeleteBook(id);
        }
    }
}
    