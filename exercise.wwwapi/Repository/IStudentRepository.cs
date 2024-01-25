using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student GetStudent(string firstName);
        Student AddStudent(Student student);

        Student UpdateStudent(string firstName, StudentPut student);
        Student DeleteStudent(string firstName);
    }
}
