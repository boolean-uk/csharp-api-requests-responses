using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student t)
        {
            return StudentCollection.AddStudent(t);

        }

        public Student Delete(string name)
        {
            return StudentCollection.DeleteStudent(name);
        }

        public Student Get(string name)
        {
            return StudentCollection.GetStudent(name);
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAllStudents();
        }

        public Student Update(string name, Student stud)
        {
            return StudentCollection.UpdateStudent(name, stud);
        }
    }
}
