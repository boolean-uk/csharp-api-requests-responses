using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentData
    {
        Student GetStudent(string firstName);
        List<Student> GetStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(string firstname, StudentPut student);
        bool DeleteStudent(string firstname);

    }
}
