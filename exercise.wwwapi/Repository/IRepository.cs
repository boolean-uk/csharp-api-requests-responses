using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {

        void Add(Student student);

        IEnumerable<Student> GetAll();
        Student GetStudentByFirstName(string firstName);
        Student UpdateStudentByFirstName(string firstname, string newFirstName, string newLastName);
        Student DeleteStudent(string firstname);
        
    }
}
