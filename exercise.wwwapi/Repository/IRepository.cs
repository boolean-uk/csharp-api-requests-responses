

namespace exercise.wwwapi.Repository;
using exercise.wwwapi.Models;
public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string FirstName);
        bool Delete(string FirstName);
        Student AddStudent(Student entity);

        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string FirstName);
        bool DeleteL(string FirstName);
        Language AddLanguage(Language entity);


        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        bool DeleteBook(int id);
        Book AddBook(Book entity);
}
