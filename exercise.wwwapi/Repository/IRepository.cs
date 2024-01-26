using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        //List<Student> GetStudents();
        IEnumerable<Student> GetStudents();

        //Student GetStudent(int id);
        Student AddStudent(Student student);
        Student UpdateStudent(int id, StudentPut studentPut);
        bool DeleteStudent(int id);



        IEnumerable<Language> GetLanguages();
        //Language GetLanguage(string name);
        Language AddLanguage(Language language);
        Language UpdateLanguage(int id, LanguagePut languagePut);
        bool DeleteLanguage(int id);



        IEnumerable<Book> GetBooks();
        //Language GetLanguage(string name);
        Book AddBook(Book book);
        Book UpdateBook(int id, BookPut bookPut);
        bool DeleteBook(int id);
    }
}
