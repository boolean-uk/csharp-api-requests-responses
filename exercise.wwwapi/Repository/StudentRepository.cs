
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {

        public List<Student> GetAll()
        {
            return StudentCollection.getAll();
        }

        public Student GetByName(string name) 
        {
            return StudentCollection.getAll().FirstOrDefault(x => x.FirstName.Equals(name));
        }

        public Student AddStudent(string firstName, string lastName)
        {
            return StudentCollection.Add(new Student() { FirstName = firstName ,LastName = lastName });
        }

        public Student UppdateStudent(string firstName, string newLastName)
        {

            Student s = StudentCollection.getAll().FirstOrDefault(x => x.FirstName.Equals(firstName));

            if (newLastName is not  null)
            {
                s.LastName = newLastName;
            }

            return s;
        }

        public Student DeleteStudent(string firstName)
        {
            Student s = StudentCollection.getAll().FirstOrDefault(x => x.FirstName.Equals(firstName));
            return StudentCollection.removeStudent(s);
        }
    }
}
