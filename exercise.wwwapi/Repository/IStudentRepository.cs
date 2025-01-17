using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IStudentRepository
{
    public IEnumerable<Student> GetAll();
    public Student Get(string firstName);
    public Student Create(Student entity);
    public Student Update(string firstName, Student updatedEntity);
    public bool Delete(string firstName);
}
