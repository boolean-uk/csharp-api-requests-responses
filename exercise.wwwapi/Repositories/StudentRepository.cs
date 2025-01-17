using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.Students;
        }
        public Student GetStudent(string LastName)
        {
            return StudentCollection.Get(LastName);
        }
        public Student AddStudent(Student entity)
        {
            return StudentCollection.Add(entity);
        }
        public Student UpdateStudent(string LastName, Student entity)
        {
            return StudentCollection.Update(LastName, entity);
        }
        public bool Delete(string LastName)
        {
            return StudentCollection.Remove(LastName);
        }
    }
}
