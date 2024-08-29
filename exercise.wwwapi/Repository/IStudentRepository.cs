using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();

        Student GetAStudent(string name);

        Student CreateStudent(string firstName, string lastName);

        Student UpdateStudent(string firstName, string newFirst, string newLast);

        Student DeleteStudent(string name);

    }
}
