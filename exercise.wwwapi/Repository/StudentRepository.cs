using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }

        public List<Student> GetAllStudents() 
        {
            return _students.GetAllStudents();
        }

        public Student AddStudent(string firstName, string lastName)
        {
            return _students.AddStudent(firstName, lastName);
        }

        public Student? GetStudent(string firstName) 
        {
            Student student = _students.GetStudent(firstName);

            if (student == null) 
            {
                throw new Exception("Student not found!");
            }
            return student;
        }

        public Student? DeleteStudent(string firstName)
        {
            Student student = _students.DeleteStudent(firstName);

            if (student == null)
            {
                throw new Exception("Student not found!");
            }

            
            return student;
        }

        public Student? UpdateStudent(StudentUpdatePayload updateData)
        {
            var student = _students.GetStudent(updateData.FirstName);

            if(student == null) 
            {
                return null;
            }

            bool hasFirstName = false;
            bool hasLastName = false;

            if(updateData.FirstName.Length > 0) 
            {
                student.FirstName = (string)updateData.FirstName;
                hasFirstName = true;
            }

            if(updateData.LastName.Length > 0) 
            { 
                student.LastName = (string)updateData.LastName;
                hasLastName = true;
            }

            if(!hasFirstName || !hasLastName)
            {
                throw new Exception("Update needs both first and last name provided!");
            }

            return student;
        }
    }
}
