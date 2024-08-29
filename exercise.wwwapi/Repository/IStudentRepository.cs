using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student CreateAStudent(Student student);
        List<Student> GetAllStudents();
        Student GetAStudent(string firstname);
        Student UpdateStudent(string firstname, string newFirstname, string newLastname);
        Student DeleteStudent(string firstname);

    }
}
