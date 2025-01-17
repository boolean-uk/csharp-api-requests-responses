namespace exercise.wwwapi.Repository;

using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

public class StudentRepository : IRepository<Student, Student>
{
    public Student Create(Student student)
    {
        return StudentCollection.Add(student);
    }

    public Student Delete(Predicate<Student> pred)
    {
        var found = StudentCollection.getAll().Find(pred);
        StudentCollection.getAll().Remove(found);
        return found;
    }

    public Student Get(Predicate<Student> pred)
    {
        return StudentCollection.getAll().Find(pred);
    }

    public IEnumerable<Student> GetAll()
    {
        return StudentCollection.getAll();
    }

    Student IRepository<Student, Student>.Update(Predicate<Student> pred, Student updated)
    {
        var found = StudentCollection.getAll().Find(pred);
        found.FirstName = updated.FirstName;
        found.LastName = updated.LastName;
        return found;
    }
}
