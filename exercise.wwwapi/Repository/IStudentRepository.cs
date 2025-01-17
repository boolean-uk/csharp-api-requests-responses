using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Student Add(Student entity);
        IEnumerable<Student> GetAll();
        Student Get(string firstName);
        Student Update(string firstName, Student entity);
        bool Delete(string firstName);
    }
}
