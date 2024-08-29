using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Student AddStudent(Student student)
        {
           return StudentCollection.Add(student);
        }

        public void DeleteStudent(string firstname)
        {
            StudentCollection.Delete(firstname);
        }

        public List<Student> GetAllStudents()
        {
            return StudentCollection.getAll();
        }

        public Student GetAStudent(string firstname)
        {
            return StudentCollection.Get(firstname);
        }

        public Student UpdateStudent(string firstname, Student studentValues)
        {
            return StudentCollection.Update(firstname, studentValues);
        }
    }
}
