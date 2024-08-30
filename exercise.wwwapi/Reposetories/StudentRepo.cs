using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposetories;

public class StudentRepo : IRepository<Student, string>
{
    public Student Get(string firstName)
    {
        return StudentCollection.GetAll().FirstOrDefault(s => s.FirstName.Equals(firstName));
    }

    public List<Student> GetAll()
    {
        return StudentCollection.GetAll();
    }

    public Student Create(Student student)
    {
        return StudentCollection.Add(student);
    }

    public Student Update(string firstName, Student student)
    {
        var s = Get(firstName);
        s.FirstName = firstName;
        s.LastName = student.LastName;
        return s;
    }

    public Student Delete(Student s)
    {
        return StudentCollection.Remove(s);
    }
}