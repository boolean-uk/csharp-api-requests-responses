using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private IStudentData _students;
        private ILanguageData _languages;
        private IBookData _books;

        public Repository(IStudentData studentCollection, ILanguageData languageCollection, IBookData books)
        {
            _students = studentCollection;
            _languages = languageCollection;
            _books = books;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _students.GetStudents();
        }
        public Student AddStudent(Student student)
        {
            return _students.AddStudent(student);
        }
        public Student GetStudent(string firstName)
        {
            var found = _students.GetStudent(firstName, out Student student);
            if (!found)
            {
                return null;
            }
            return student;
        }
        public Student DeleteStudent(string firstName)
        {
            var found = _students.DeleteStudent(firstName, out Student student);
            if (found == null)
            {
                return null;
            }
            return student;
        }
        public Student UpdateStudent(string firstName, Student newStudent)
        {
            var found = _students.GetStudent(firstName, out Student student);
            if (!found)
            {
                return null;
            }
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            return student;
        }
        public IEnumerable<Language> GetLanguages()
        {
            return _languages.GetLanguages();
        }
        public Language AddLanguage(Language language)
        {
            return _languages.AddLanguage(language);
        }
        public Language GetLanguage(string firstName)
        {
            var found = _languages.GetLanguage(firstName, out Language language);
            if (!found)
            {
                return null;
            }
            return language;
        }
        public Language DeleteLanguage(string firstName)
        {
            var found = _languages.DeleteLanguage(firstName, out Language language);
            if (found == null)
            {
                return null;
            }
            return language;
        }
        public Language UpdateLanguage(string firstName, Language newLanguage)
        {
            var found = _languages.GetLanguage(firstName, out Language language);
            if (!found)
            {
                return null;
            }
            language.Name = newLanguage.Name;
            return language;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _books.GetBooks();
        }
        public Book AddBook(Book book)
        {
            return _books.AddBook(book);
        }
        public Book GetBook(int id)
        {
            var found = _books.GetBook(id, out Book book);
            if (!found)
            {
                return null;
            }
            return book;
        }
        public Book DeleteBook(int id)
        {
            var found = _books.DeleteBook(id, out Book book);
            if (found == null)
            {
                return null;
            }
            return book;
        }
        public Book UpdateBook(int id, BookPut newBook)
        {
            var found = _books.GetBook(id, out Book book);
            if (!found)
            {
                return null;
            }
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Genre = newBook.Genre;
            book.NumPages = newBook.NumPages;
            return book;
        }
    }
}
