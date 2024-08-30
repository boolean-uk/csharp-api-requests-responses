using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student AddStudent(string firstName, string lastName);
        Student DeleteStudent(string firstName);
        List<Student> GetAll();

        Student GetByName(string firstName);
        Student UppdateStudent(string firstName, string newFirstName, string newLastName);
    }
}
