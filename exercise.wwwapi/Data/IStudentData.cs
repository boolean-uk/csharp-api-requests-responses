using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public interface IStudentData
{
    Student AddStudent(Student student);
    List<Student> GetStudents();
    Student DeleteStudent(string firstName);
}
