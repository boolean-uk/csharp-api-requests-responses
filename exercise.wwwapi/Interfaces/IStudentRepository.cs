using exercise.wwwapi.Models;

namespace exercise.wwwapi.Interfaces
{
    public interface IStudentRepository
    {
        Student Add(Student student);
        List<Student> GetAll();
        Student Get(string firstName);
        Student Update(string firstName , Student updatedStudent);
        Student Delete(string firstName);

    }
}
