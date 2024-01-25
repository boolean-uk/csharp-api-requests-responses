using exercise.wwwapi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Student AddStudent(Student student);
        IEnumerable<Student> GetStudents();
        Student UpdateStudent(string firstName, StudentPut studentPut);
        Student GetStudentByFirstName(string firstName);
        Student DeleteStudent(string firstName);
        IEnumerable<Language> GetLanguages();
        Language AddLanguage(Language language);
        Language UpdateLanguage(string name, LanguagePut languagePut);
        Language GetLanguageByName(string name);
        Language DeleteLanguage(string name);
        Book AddBook(BookPost book);
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        Book UpdateBook(int id, BookPut bookPut);
        Book DeleteBookById(int id);
    }
}
