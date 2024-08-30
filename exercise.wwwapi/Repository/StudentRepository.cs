using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student AddStudent(Student student)
        {
            StudentCollection.Add(student);
            return student;
        }

        public Student DeleteStudent(string FirstName)
        {
            Student student = StudentCollection.Delete(FirstName);
            return student;
        }

        public Student GetStudent(string FirstName)
        {
            return StudentCollection.GetStudent(FirstName);
        }

        public List<Student> GetStudents()
        {
            return StudentCollection.GetAll();
        }

        public Student UpdateStudent(string FirstName, Student student)
        {
            return StudentCollection.UpdateStudent(FirstName, student);
        }
    }
}
