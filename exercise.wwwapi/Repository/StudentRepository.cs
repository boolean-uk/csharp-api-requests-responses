using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository
    {
        public void Add(Student student)
        {
            StudentCollection.Add(student);
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student GetStudentByFirstName(string firstname)
        {
            return StudentCollection.GetStudentByFirstName(firstname);
        }

        public Student UpdateStudentByFirstName(string firstname, string newFirstName, string newLastName)
        {

            return StudentCollection.UpdateStudentInfo(firstname, newFirstName, newLastName);
        }

        public Student DeleteStudent(string firstname)
        {
            return StudentCollection.DeleteStudent(firstname);
        }

        
       
    }
}

