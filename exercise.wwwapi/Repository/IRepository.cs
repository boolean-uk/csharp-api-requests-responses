using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student AddStudent(Student student);
        Student GetStudent(string firstName);
        Student UpdateStudent(string firstName, string updatedFirstName); 
        Student DeleteStudent(string firstName, string lastName);

        // ----- Languages ---------

        IEnumerable<Language> GetLanguages(); 
        Language AddLanguage(Language language);
        Language GetLanguage(string name);
        Language UpdateLanguage(string name, string updatedName);
        Language DeleteLanguage(string name);

        // ------ Book -----------
        IEnumerable<Book> GetBooks(); 
        Book AddBook(Book book);
        Book GetBook(int id);
        Book UpdateBook(int id, string newTitle, string newAuthor, string newGenre, int newNumPages);
        Book DeleteBook(int id);
    }
}
