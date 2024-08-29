using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student AddStudent(Student student);

        List<Student> GetStudents();

        Student GetStudent(int id);

        Student UpdateStudent(Student student);

        Student DeleteStudent(int id);
    }
}
