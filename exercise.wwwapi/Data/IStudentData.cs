using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentData
    {
        List<Student> GetAll();
        Student Add(Student student);
        Student Get(string firstName);
        Student Update(string firstName, Student student);
        Student Delete(string firstName);
    }
}
