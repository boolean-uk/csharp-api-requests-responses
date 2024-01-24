using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetOneStudent(string FirstName);
        Student AddStudent(Student student);
        Student UpdateStudent(string FirstName, Student newStudent);
        Student DeleteStudent(string FirstName);

        IEnumerable<Language> GetLanguages();
        Language GetOneLanguage(string FirstName);
        Language AddLanguage(Language language);
        Language UpdateLanguage(string name, Language language);
        Language DeleteLanguage(string name);

        IEnumerable<Book> GetBooks();
        Book GetOneBook(int id);
        Book AddBook(InputBook input);
        Book UpdateBook(int id, InputBook inputBook);
        Book DeleteBook(int id);
    }
}
