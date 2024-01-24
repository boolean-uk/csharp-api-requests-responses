using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IStudentRepository
{
    Student AddStudent(Student student);
    IEnumerable<Student> GetStudents();
    Student DeleteStudent(string firstName);
}
