using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface IStudentRepository
{
    IEnumerable<Student> GetStudents();
    Student GetStudent(string firstname);
    bool DeleteStudent(string firstname);
    Student AddStudent(Student student);
    Student UpdateStudent(string firstname, Student student);
}
