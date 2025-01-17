using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IRepository
    {
        public void CreateStudent(Student entity)
        {
            StudentCollection.Add(entity);
        }

        public void DeleteStudent(string firstname)
        {
            StudentCollection.Delete(firstname);
        }

        public Student GetStudent(string firstname)
        {
            return StudentCollection.Get(firstname);
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.getAll();
        }

        public void UpdateStudent(string firstname, string newFirstName, string newLastName)
        {
            StudentCollection.Uppdate(firstname, newFirstName, newLastName);    
        }
    }
}
