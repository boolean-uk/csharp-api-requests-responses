using System.Diagnostics;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository <Student>
    {
        public Student AddEntity(Student student)
        {
            StudentCollection.Add(student);

            return student;
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student GetEntity(string firstname)
        {
            return StudentCollection.Get(firstname);
        }

        // Returns the removed student
        public Student RemoveEntity(string firstname)
        {
            return StudentCollection.Remove(firstname);
        }

    }
}
