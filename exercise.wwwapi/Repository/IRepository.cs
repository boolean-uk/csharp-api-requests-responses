using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        // Student part
        IEnumerable<Student> GetStudents();
        Student GetStudent(string firstName);
        bool DeleteStudent(string firstName);
        Student AddStudent(Student student);

        //Language part

        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string name);
        bool DeleteLanguage(string name);
        Language AddLanguage(Language language);

        // Book part

        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        bool DeleteBook(int id);
        Book AddBook(Book book);
    }
}
