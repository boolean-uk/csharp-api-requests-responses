using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Student CreateStudent(string firstName, string lastName)
        {
            Student newStudent = new Student() {FirstName = firstName, LastName = lastName };
            StudentCollection.Add(newStudent);

            return newStudent;
        }

        public Student DeleteStudent(string name)
        {
            Student studentToBeDeleted = StudentCollection.Delete(name);
            return studentToBeDeleted;
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }
        public Student GetAStudent(string name)
        {
            return StudentCollection.GetAll().FirstOrDefault(stud => stud.FirstName == name);
        }

        public Student UpdateStudent(string firstName, string newFirst, string newLast)
        {
            Student studentToBeUpdated = StudentCollection.GetAll().FirstOrDefault(stud => stud.FirstName == firstName);
            studentToBeUpdated.FirstName = newFirst;
            studentToBeUpdated.LastName = newLast;

            return studentToBeUpdated;
        }
    }
}
