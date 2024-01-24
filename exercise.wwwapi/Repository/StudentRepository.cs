using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class StudentRepository : IStudentRepository
{
    private IStudentData _studentDatabase;

    public StudentRepository(IStudentData studentDatabase)
    {
        _studentDatabase = studentDatabase;
    }

    public Student AddStudent(Student student)
    {
        return _studentDatabase.AddStudent(student);
    }

    public IEnumerable<Student> GetStudents()
    {
        return _studentDatabase.GetStudents();
    }

    public Student DeleteStudent(string firstName)
    {
        return _studentDatabase.DeleteStudent(firstName);
    }
}
