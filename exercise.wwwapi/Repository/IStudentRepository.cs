using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student AddStudent(Student student);

        List<Student> GetStudents();

        Student GetStudent(string FirstName);

        Student UpdateStudent(string FirstName, Student student);

        Student DeleteStudent(string FirstName);
    }
}
