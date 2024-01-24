using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    //public interface IRepository <T>   //--> and then IEnumerable<T> GetStudents();
    public interface IRepository
    {


        // For student:
        IEnumerable<Student> GetStudents();
        public Student AddStudent(Student student); // Return also student!
        public Student Remove(Student student);

        IEnumerable<Language> GetLanguages();
        public Language AddLanguage(Language language);
        public Language RemoveLanguage(Language language);

        public IEnumerable<Book> GetBooks();
        public Book AddBook(Book book);
        public Book RemoveBook(Book book);


        /* IEnumerable<T> Get();
         public T Add(T t); // Return also student!
         public T Remove(T t); 
 */
    }
}
