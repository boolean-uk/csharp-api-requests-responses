using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        List<Student> GetStudents();
        Student AddStudent(Student entity);

        Student GetStudent(string firstName);

        Student UpdateStudent(Student newStudent, string firstName);
    }
}
