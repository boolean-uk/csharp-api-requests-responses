using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _Database;

        public Repository(DataCollection carDatabase)
        {
            _Database = carDatabase;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _Database.getAllStudents();
        }

        public Student AddStudent(Student student)
        {
            return _Database.AddStudent(student);
        }

        public Student GetAStudent(string firstname)
        {
            return _Database.GetStudent(firstname);
        }

        public Student UpdateStudent(string firstname, Student student)
        {
            return _Database.UpdateStudent(firstname, student);
        }

        public Student DeleteAStudent(string firstname)
        {
            return _Database.DeleteStudent(firstname);
        }

        public Languages AddLanguage(Languages language)
        {
            return _Database.AddLanguage(language);
        }

        public IEnumerable<Languages> GetLanguage()
        {
            return _Database.getAllLanguages();
        }

        public Languages GetALanguage(string name)
        {
            return _Database.GetLanguage(name);
        }

        public Languages UpdateALanguage(string name, Languages language)
        {
            return (_Database.UpdateLanguage(name, language));
        }

        public Languages DeleteALanguage(string name)
        {
            return _Database.DeleteLanguage(name);
        }

        public Book AddBook(InPuBook book)
        {
            return _Database.AddBook(book);
        }

        public IEnumerable<Book> GetBook()
        {
            return _Database.getAllBooks();
        }

        public Book GetABook(int id)
        {
            return _Database.GetBook(id);
        }

        public Book UpdateABook(int id, InPuBook book)
        {
            return (_Database.UpdateBook(id, book));
        }

        public Book DeleteABook(int id)
        {
            return _Database.DeleteBook(id);
        }
    }
}
