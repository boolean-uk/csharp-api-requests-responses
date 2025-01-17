using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudents
    {
        List<Student> GetStudents();

        Student GetStudent(string firstName);

        Student AddStudent(Student student);
        Student UpdateStudent(Student student, string firstName);
        Student DeleteStudent(string firstName);

    }
}
