using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentData
    {
        Student GetStudent(string firstName);
        List<Student> GetStudents();
    }
}
