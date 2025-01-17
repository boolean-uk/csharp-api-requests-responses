using System;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class StudentRepository : IStudentRepository
{
    public StudentRepository()
    {
    }

    public Student AddStudent(Student student)
    {
        return StudentCollection.Add(student);
    }

    public bool DeleteStudent(string firstname)
    {
        return StudentCollection.DeleteStudent(firstname);
    }

    public Student GetStudent(string firstname)
    {
        return StudentCollection.GetStudent(firstname);
    }

    public IEnumerable<Student> GetStudents()
    {
        return StudentCollection.GetAll();
    }

    public Student UpdateStudent(string firstname, Student student)
    {
        return StudentCollection.UpdateStudent(firstname, student);
    }
}
