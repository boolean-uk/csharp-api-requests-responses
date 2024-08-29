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

        public Student DeleteStudent(int id)
        {
            Student student = StudentCollection.Delete(id);
            return student;
        }

        public Student GetStudent(int id)
        {
            return StudentCollection.GetStudent(id);
        }

        public List<Student> GetStudents()
        {
            return StudentCollection.GetAll();
        }

        public Student UpdateStudent(Student student)
        {
            return StudentCollection.UpdateStudent(student);
        }
    }
}
