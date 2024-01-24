
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Payload;


namespace exercise.wwwapi.Repository {

    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;

        public StudentRepository(StudentCollection students) {
            _students = students;
        }
        
        public Student AddStudent(string FirstName, string LastName)
        {
            return _students.Add(new Student(FirstName, LastName));
        }

        public Student DeleteStudent(string FirstName)
        {
            var student = _students.get(FirstName);
            if(student == null)
                return null;
            _students.Remove(student);
            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _students.Students;
        }

        public Student? GetStudent(string FirstName)
        {
            return _students.get(FirstName);
        }

        public Student UpdateStudent(string FirstName, StudentUpdatePayload updateData)
        {
            var student = _students.get(FirstName);
            if (student == null)
            {
                return null;
            }

            bool hasUpdate = false;

            if(updateData.FirstName != null)
            {
                student.FirstName = (string)updateData.FirstName;
                hasUpdate = true;
            }

            if(updateData.LastName != null)
            {
                student.LastName = (string)updateData.LastName;
                hasUpdate = true;
            }

            if(!hasUpdate) throw new Exception("No update data provided");

            return student;
        }
    }
}