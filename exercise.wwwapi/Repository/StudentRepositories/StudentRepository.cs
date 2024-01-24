using exercise.wwwapi.Data;
using exercise.wwwapi.Models.Student;

namespace exercise.wwwapi.Repository.StudentRepositories
{
    public class StudentRepository : IStudentRepositiry
    {

        private StudentCollection _students;

        public StudentRepository(StudentCollection students)
        {
            _students = students;
        }
        public Student AddStudent(StudentPostPayload payload)
        {
            return _students.Add(payload);
        }

        public bool DeleteStudent(string firstname)
        {
            return _students.deleteStudentByName(firstname);
        }

        public List<Student> GetAllStudents()
        {
            return _students.getAll();
        }

        public Student GetStudent(string firstname)
        {
            return _students.getStudentByName(firstname);
        }

        public Student UpdateStudent(string firstname, StudentPutPayload payload)
        {
            Student tmpStudent = _students.getStudentByName(firstname);
            if (tmpStudent == null)
            {
                return null;
            }

            bool isUpdated = false;

            if (payload.firstname != null && payload.firstname.Length > 0)
            {
                tmpStudent.FirstName = payload.firstname;
                isUpdated = true;
            }

            if (payload.lastname != null && payload.lastname.Length > 0)
            {
                tmpStudent.LastName = payload.lastname;
                isUpdated = true;
            }

            if (!isUpdated)
            {
                throw new Exception("No updated date provided");
            }

            return tmpStudent;
        }
    }
}
