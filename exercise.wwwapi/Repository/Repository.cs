using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        public IStudent _studentDatabase;

        public Repository(IStudent studentDatabase)
        {
            _studentDatabase = studentDatabase;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentDatabase.GetStudents();
        }

        public Student AddStudent(Student student)
        {
            return _studentDatabase.AddStudent(student);
        }

        public Student UpdateStudent(int id, StudentPut studentPut)
        {
            var existingStudent = _studentDatabase.GetStudent(id);
            if (existingStudent == null)
                return null;

            existingStudent.FirstName = studentPut.FirstName;
            existingStudent.LastName = studentPut.LastName;
            return existingStudent;
        }

        public bool DeleteStudent(int id)
        {
            return _studentDatabase.DeleteStudent(id);
        }


    }
}

