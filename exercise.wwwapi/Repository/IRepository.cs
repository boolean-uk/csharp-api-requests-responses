using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public enum StudentQuerryOption
    {
        FirstName,
        LastName,
        FullName,
    }

    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string name);
        Student CreateStudent(Student student);
        Student UpdateStudent(string studentName, string firstName);
        bool DeleteStudent(string studentName);


        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string language);
        Language CreateLanguage(Language language);
        Language UpdateLanguage(string language, string newLanguage);
        bool DeleteLanguage(string language);


        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book CreateBook(Book book);
        Book UpdateBook(int id, Book newBook);
        bool DeleteBook(int id);
    }
}
