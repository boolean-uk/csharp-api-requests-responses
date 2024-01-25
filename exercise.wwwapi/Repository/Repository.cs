using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _data;

        public Repository(DataCollection data)
        {
            _data = data;
        }

        public Book AddBook(BookPost book)
        {
            return _data.AddBook(book);
        }

        public Language AddLanguage(Language language)
        {
            return _data.AddLanguage(language);
        }

        public Student AddStudent(Student student)
        {
            return _data.AddStudent(student);  
        }

        public Book DeleteBookById(int id)
        {
            return _data.DeleteBookById(id);
        }

        public Language DeleteLanguage(string name)
        {
            return _data.DeleteLanguage(name);
        }

        public Student DeleteStudent(string firstName)
        {
            return _data.DeleteStudent(firstName);
        }

        public Book GetBookById(int id)
        {
            return _data.GetBookById(id);   
        }

        public IEnumerable<Book> GetBooks()
        {
            return _data.GetBooks();
        }

        public Language GetLanguageByName(string name)
        {
            return _data.GetLanguageByName(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _data.GetLanguages();
        }

        public Student GetStudentByFirstName(string firstName)
        {
            return _data.GetStudentByFirstName(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _data.GetStudents();
        }

        public Book UpdateBook(int id, BookPut bookPut)
        {
            return _data.UpdateBook(id, bookPut);
        }

        public Language UpdateLanguage(string name, LanguagePut languagePut)
        {
            return _data.UpdateLanguage(name, languagePut);
        }

        public Student UpdateStudent(string firstName, StudentPut studentPut)
        {
            return _data.UpdateStudent(firstName, studentPut);
        }

    }
}
