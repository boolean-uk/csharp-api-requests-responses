using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Reposity
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student Student)
        {
            StudentCollection.Add(Student);
            return Student;
        }

        public Student Delete(string FirstName)
        {
            Student stud = StudentCollection.Delete(FirstName);
            return stud;
        }

        public Student Get(string FirstName)
        {
            return StudentCollection.Get(FirstName);
        }

        public List<Student> getAll()
        {
            return StudentCollection.getAll();
        }

        public Student Update(string FirsName, Student student)
        {
            return StudentCollection.Update(FirsName, student);
        }
    }
}
