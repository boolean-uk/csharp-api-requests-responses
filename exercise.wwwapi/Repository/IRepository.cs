using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> getStudentCollections();

        IEnumerable<Student> getStudent(string firstName);

        Student addStudent(string firstName, string lastName);

        Student updateStudent(string firstName, string newFirstName, string newLastName);

        Student deleteStudent(string firstName);

        Language createLanguage(string name);

        IEnumerable<Language> getLanguageCollections();

        Language getLanguage(string name);

        Language updateLanguage(string name, string newName);

        Language deleteLanguage(string name);

        Book createBook(Book book);
        IEnumerable<Book> getAllBooks();
        Book getBook(int id);
        Book updateBook(int id, Book book);

        Book deleteBook(int id);

    }
}
