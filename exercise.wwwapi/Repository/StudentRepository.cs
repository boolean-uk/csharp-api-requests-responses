using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public Student Add(Student entity)
        {
            StudentCollection.AddStudent(entity);
            return entity;
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetStudents();
        }

        public Student GetOne(string firstname)
        {
            return StudentCollection.GetAStudent(firstname);
        }
        public Student Update(string firstname, string updatedName)
        {
            return StudentCollection.UpdateStudent(firstname, updatedName);
        }

        public Student Delete(string firstname)
        {
            return StudentCollection.DeleteStudent(firstname);
        }


       

    }
}
