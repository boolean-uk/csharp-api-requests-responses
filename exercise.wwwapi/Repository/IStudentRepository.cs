using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        Student AddStudent(Student student);

        Student GetStudent(string firstname);

        Student UpdateStudent(string firstname, Student student);

        Student DeleteStudent(string firstname);
    }
}
