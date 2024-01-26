using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Student InsertStudent(Student student);
        Language InsertLanguage(Language language);
        Book InsertBook(BookCreate book);

        IEnumerable<Student> GetStudents();
        IEnumerable<Language> GetLanguages();
        IEnumerable<Book> GetBooks();

        Student GetStudentById(string firstName);
        Language GetLanguageById(string name);
        Book GetBookById(int id);

        Student UpdateStudent(string firstName, Student student);
        Language UpdateLanguage(string name, Language language);
        Book UpdateBook(int id, BookCreate book);

        Student DeleteStudent(string firstName);
        Language DeleteLanguage(string name);
        Book DeleteBook(int id);

    }
}
