using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student AddStudent(Student student)
        {
            StudentCollection.AddStudent(student);
            return student;
        }
        public List<Student> GetAllStudents()
        {
            return StudentCollection.GetAll();
        }

        public Student GetStudent(string firstname)
        {
            return StudentCollection.GetStudent(firstname);
        }

        public Student UpdateStudent(string firstname, Student student)
        {
            return StudentCollection.UpdateStudent(firstname, student);
        }

        public Student DeleteStudent(string firstname)
        {
            return StudentCollection.DeleteStudent(firstname);
        }
    }
}
