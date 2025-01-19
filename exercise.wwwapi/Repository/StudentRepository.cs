using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository
    {
        public void Add(Student student)
        {

            StudentCollection.AddStudent(student);
        
        }

        public List<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }

        public Student DeleteStudent(string firstName)
        {
            return StudentCollection.DeleteStudent(firstName);
        }


        public Student GetStudent(string firstName)
        {
            return StudentCollection.GetStudent(firstName);
        }

        public Student UpdateStudent(string firstName, string newFirstName, string newLastName)
        {
            return StudentCollection.UpdateStudent(firstName, newFirstName, newLastName);
        }
    }
}
