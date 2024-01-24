using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Threading.Tasks;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection students;

        public StudentRepository(StudentCollection students)
        {
            this.students = students;
        }

        public List<Student> GetAllStudents()
        {
            return students.GetAll();
        }

        public Student AddStudent(string firstName, string lastName)
        {
            return students.Add(firstName, lastName);
        }

        public Student? GetStudent(int id)
        {
            return students.Get(id);
        }

        public Student? UpdateStudent(Student student, StudentUpdatePayload updateData) 
        {
            bool hasUpdate = false;

            if (updateData.firstName != null)
            {
                student.FirstName = (string)updateData.firstName;
                hasUpdate = true;
            }

            if (updateData.lastName != null)
            {
                student.LastName = (string)updateData.lastName;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");

            return student;
        }

        public List<Student> DeleteStudent(int id)
        {
            students.Delete(id);
            return students.GetAll();
        }
    }
}
