using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepo<Student, string>
    {
        public Student Add(Student student)
        {
            return StudentCollection.Add(student);
        }

        public void Delete(string firstname)
        {
            StudentCollection.Delete(firstname);
        }

        public Student Get(string firstname)
        {
            return StudentCollection.Get(firstname);
        }

        public List<Student> getAll()
        {
            return StudentCollection.getAll();
        }

        public Student Update(Student student, string firstname)
        {
            return StudentCollection.Update(student, firstname);

        }
    }
}
