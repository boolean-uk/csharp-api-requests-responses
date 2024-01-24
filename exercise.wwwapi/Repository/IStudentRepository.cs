using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> Get();
        Student Add(Student student);
        Student Get(string firstName);

        Student Update(string firstName, Student student);

        Student Delete(string  firstName);
       
    }
}
