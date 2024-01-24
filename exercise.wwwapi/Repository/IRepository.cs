using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        List<Student> GetStudents();
        Student GetStudent(string name);
        Student AddStudent(Student student);
        Student UpdateStudent(string name, Student student);
        void DeleteStudent(string name);

        List<Language> GetLanguages();
        Language GetLanguage(string name);
        Language AddLanguage(Language language);
        Language UpdateLanguage(string name, Language language);
        void DeleteLanguage(string name);

        List<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(int id, Book book);
        void DeleteBook(int id);
    }
}
