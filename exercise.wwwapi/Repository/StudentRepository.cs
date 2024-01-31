using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    //repository
    public class StudentRepository:IStudentRepository
    {
        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }
        public List<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Student DeleteStudent(string name)
        {
            return _students.DeleteStudent(name);
        }

        public Student Add(string firstname, string lastname) 
        {
            return _students.Add(firstname, lastname);
        }

        public Student GetStudentItem(string firstname)
        {
            return _students.GetStudentItem(firstname);
        }
        public Student? UpdateStudent(string firstname, StudentItemUpdate updateData) 
        {
            var student = _students.GetStudentItem(firstname);
            if ( student == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if (updateData.Firstname != null)
            {
                student.FirstName = (string)updateData.Firstname;
                hasUpdate = true;
            }

            if (updateData.Lastname != null)
            {
                student.LastName = (string)updateData.Lastname;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return student;
        }
    }
}
