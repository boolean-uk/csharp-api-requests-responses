using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Student CreateStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudent(string firstname);
        Student UpdateStudent(string firstname, Student student);
        Student DeleteStudent(string firstName);
    }
}
 