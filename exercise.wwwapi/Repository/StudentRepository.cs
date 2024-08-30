using exercise.wwwapi.Data;
using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Create(Student student)
        {
            return StudentCollection.Create(student);
        }

        public Student Delete(string firstname)
        {
            return StudentCollection.DeleteStudent(firstname);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student Get(string firstname)
        {
            return StudentCollection.GetStudent(firstname);
        }

        public Student Update(string firstname, Student student)
        {
            return StudentCollection.UpdateStudent(firstname, student);
        }
    }
}
