using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();
        Student Get(string firstName);
        Student Add(Student student);
        Student Update(string firstName, Student student);
        Student Remove(string firstName);
    }
}
