using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data;

public class StudentCollection : IStudentData
{
    private List<Student> _students = new List<Student>()
    {
        new Student() { FirstName="Nathan",LastName="King" },
        new Student() { FirstName="Dave", LastName="Ames" }
    };

    public Student AddStudent(Student student)
    {
        _students.Add(student);

        return student;
    }

    public List<Student> GetStudents()
    {
        return _students;
    }

    public Student DeleteStudent(string firstName)
    {
        var toDelete = _students.FirstOrDefault(x => x.FirstName == firstName);
        if (toDelete != null)
        {
            _students.Remove(toDelete);
        }
        return toDelete;
    }
};
