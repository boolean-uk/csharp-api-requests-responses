using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRespository : IRepository
    {
        public Student AddStudent(Student entity)
        {
            StudentCollection.Add(entity);
            return entity;
        }

        public List<Student> GetStudents()
        {
            return StudentCollection.GetAll();
        }

        public Student GetStudent(string firstName)
        {
            return StudentCollection.GetStudent(firstName);
        }

        public Student UpdateStudent(Student newStudent, string firstName)
        {
            return StudentCollection.UpdateStudent(newStudent, firstName);
        }
    }
}
