using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentData
    {
        IEnumerable<Student> GetStudents();
        Student AddStudent(Student student);
        Student UpdateStudent(string firstName, Student newStudent);
        Student DeleteStudent (string firstName, out Student student);
        bool GetStudent(string firstName, out Student student);
    }
}
