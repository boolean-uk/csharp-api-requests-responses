using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRespository : IRepository<Student>
    {
        public Student AddClass(Student entity)
        {
            StudentCollection.Add(entity);
            return entity;
        }

        public List<Student> GetClasses()
        {
            return StudentCollection.GetAll();
        }

        public Student GetClass(string firstName)
        {
            return StudentCollection.GetStudent(firstName);
        }

        public Student UpdateClass(Student newStudent, string firstName)
        {
            return StudentCollection.UpdateStudent(newStudent, firstName);
        }

        public Student DeleteClass( string firstName)
        {
            return StudentCollection.DeleteStudent(firstName);
        }
    }
}



