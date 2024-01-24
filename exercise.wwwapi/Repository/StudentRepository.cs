using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository
    {
        private StudentCollection _students { get; set; }
        public StudentRepository(StudentCollection students)
        {
            this._students = students;
        }

        public Student CreateStudent(Student student) 
        {
            return this._students.Add(student);
        }

        public List<Student> GetAllStudents() 
        {
            return this._students.getAll();
        }

        public Student GetStudent(string firstname) 
        {
            return this._students.GetStudent(firstname);
        }

        public Student UpdateStudent(string firstname, Student student) 
        {
            return this._students.UpdateStudent(firstname, student);
        }

        public Student DeleteStudent(string firstName) 
        {
            return this._students.DeleteStudent(firstName);
        }
    }
}
