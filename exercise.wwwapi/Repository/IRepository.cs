using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Student AddStudent(Student student);

        public IEnumerable<Student> GetStudents();

        public Student GetAStudent(string firstname);

        public Student UpdateStudent(string firstname, Student student);
        
        public Student DeleteAStudent(string firstname);

        public Languages AddLanguage(Languages language);

        public IEnumerable<Languages> GetLanguage();

        public Languages GetALanguage(string name);

        public Languages UpdateALanguage(string name, Languages language);

        public Languages DeleteALanguage(string name);

        public Book AddBook(InPuBook book);

        public IEnumerable<Book> GetBook();

        public Book GetABook(int id);

        public Book UpdateABook(int id, InPuBook book);

        public Book DeleteABook(int id);
    }
}
