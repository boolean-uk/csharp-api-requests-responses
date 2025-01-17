using System;
using System.Net.Http.Headers;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public class StudentRepository : IStudentRepository
{
    public Student Create(Student entity)
    {
        return StudentCollection.Add(entity);
    }

    public bool Delete(string firstName)
    {
        return StudentCollection.Delete(firstName);
    }

    public Student Get(string name)
    {
        return StudentCollection.Get(name);
    }

    public IEnumerable<Student> GetAll()
    {
        return StudentCollection.GetAll();
    }

    public Student Update(string firstName, Student updatedEntity)
    {
        return StudentCollection.Update(firstName, updatedEntity);
    }

}
