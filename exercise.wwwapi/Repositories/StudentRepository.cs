using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IStudentRepository
    {
        Student CreateStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudent(string firstName);
        Student UpdateStudent(string firstName, Student newInfo);
        Student DeleteStudent(string firstName);

    }

    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _studentCollection;
        public StudentRepository(StudentCollection sc)
        {
            _studentCollection = sc;
        }

        public Student CreateStudent(Student student)
        {
            _studentCollection.Add(student);
            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            return _studentCollection.Delete(firstName);
        }

        public List<Student> GetAllStudents()
        {
            return _studentCollection.getAll();
        }

        public Student GetStudent(string firstName)
        {
            return _studentCollection.getStudentByFirstname(firstName);
        }

        public Student UpdateStudent(string firstName, Student newInfo)
        {
            return _studentCollection.Update(firstName, newInfo);
        }
    }
}
