
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Data
{
    public interface IStudent
    {
        
        Student AddStudent(Student student);
        Student GetStudent(int id);
        IEnumerable<Student> GetStudents();
        bool DeleteStudent(int id);
    }

}



