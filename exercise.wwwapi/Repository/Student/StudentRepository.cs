using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection studentCollection;
        public StudentRepository(StudentCollection studentCollection)
        {
            this.studentCollection = studentCollection;
        }

        public List<Student> GetAllStudents()
        {
            return studentCollection.Students;
        }
        public Student AddStudent(string firstName, string lastName)
        {
            Student student = new Student(firstName, lastName);

            studentCollection.Students.Add(student);

            return student;
        }

        public Student? DeleteStudent(string firstName)
        {
            var student = studentCollection.Students.FirstOrDefault(s => s.FirstName == firstName);

            if (student == null)
            {
                return null;
            }

            studentCollection.Students.Remove(student);

            return student;
        }

        public Student? GetStudent(string firstName)
        {
            return studentCollection.Students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student? UpdateStudent(string firstName, StudentUpdatePayload studentUpdatePayload)
        {
            var student = studentCollection.Students.FirstOrDefault(s => s.FirstName == firstName);

            if (student == null)
            {
                return null;
            }

            if (studentUpdatePayload.FirstName != null)
            {
                student.FirstName = studentUpdatePayload.FirstName;
            }

            return student;
        }
    }
}