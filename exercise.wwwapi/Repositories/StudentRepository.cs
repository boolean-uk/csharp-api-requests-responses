using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IGenericRepository<Student>
    {
        public Student Add(Student entity)
        {
            entity.Id = StudentCollection.Students.Max(x => x.Id) + 1;
            StudentCollection.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            Student student = Get(id);
            return StudentCollection.Remove(student);
        }

        public Student Get(int id)
        {
            Student student = StudentCollection.Students.FirstOrDefault(x => x.Id == id);
            return student ?? throw new ArgumentException("That ID does not exist!");
        }

        public Student Get(Func<Student, bool> condition)
        {
            Student student = StudentCollection.Students.Where(condition).FirstOrDefault();
            return student ?? throw new ArgumentException("No student fit that condition!");
        }

        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.Students;
        }

        public Student Update(int id, Student entity)
        {
            Student student = Get(id);
            student.FirstName = entity.FirstName ?? student.FirstName;
            student.LastName = entity.LastName ?? student.LastName;
            return student;
        }
    }
}
