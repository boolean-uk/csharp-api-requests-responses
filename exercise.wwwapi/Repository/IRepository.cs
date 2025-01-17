using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(string firstName);
        Student AddStudent(Student student);
        Student UpdateStudent(string firstName, Student student);
        bool DeleteStudent(string firstName);

    }
}
