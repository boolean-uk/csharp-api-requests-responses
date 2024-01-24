using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection students;
        private DataCollection languages;
        private DataCollection books;
        public Repository(DataCollection studentCollection, DataCollection languageCollection, DataCollection bookCollection) 
        {
            students = studentCollection;
            languages = languageCollection;
            books = bookCollection;
        }

        // ---------------------- Student ---------------------------

        public Student AddStudent(Student student)
        {
            students.AddStudent(student);
            return student;
        }

        public Student DeleteStudent(string firstName, string lastName)
        {
            var student = students.GetVerySpecificStudent(firstName, lastName);
            students.RemoveStudent(student);
            return student;
        }

        public Student GetStudent(string firstName)
        {
            var student = students.GetSpecificStudent(firstName);
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            return students.GetAllStudents();
        }

        public Student UpdateStudent(string firstName, string updatedFirstName)
        {
            var updatedStudent = students.GetSpecificStudent(firstName);
            updatedStudent.FirstName = updatedFirstName; 
            return updatedStudent;
        }

        // ---------------------- Language -----------------------

        public Language AddLanguage(Language language)
        {
            languages.AddLanguage(language);
            return language;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return languages.GetAllLanguages(); 
        }

        public Language GetLanguage(string name)
        {
            var language = languages.GetSpecificLanguage(name);
            return language;
        }

        public Language UpdateLanguage(string name, string newName)
        {
            var updatedLanguage = languages.GetSpecificLanguage(name);
            updatedLanguage.name = newName;
            return updatedLanguage;
        }

        public Language DeleteLanguage(string name)
        {
            var language = languages.GetSpecificLanguage(name);
            languages.RemoveLanguage(language);
            return language; 
        }

        // ------------ Book ---------------------

        public IEnumerable<Book> GetBooks()
        {
            return books.GetAllBooks();
        }

        public Book AddBook(Book book)
        {
            books.AddBook(book);
            return book;
        }

        public Book GetBook(int id)
        {
            var book = books.GetSpecificBook(id);
            return book;
        }

        public Book UpdateBook(int id, string newTitle, string newAuthor, string newGenre, int newNumPages)
        {
            var updatedBook = books.GetSpecificBook(id);
            updatedBook.Title = newTitle;
            updatedBook.Author = newAuthor;
            updatedBook.Genre = newGenre;   
            updatedBook.NumPages = newNumPages;
            return updatedBook;
        }

        public Book DeleteBook(int id)
        {
            var book = books.GetSpecificBook(id);
            books.RemoveBook(book);
            return book;
        }
    }
}
