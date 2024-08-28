namespace exercise.wwwapi.Repository
{
    using exercise.wwwapi.Data;
    using exercise.wwwapi.Models;
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _studentCollection;

        public StudentRepository(StudentCollection students)
        {
            _studentCollection = students;
        }

        public Student Create(Student student)
        {
            return _studentCollection.Add(student);
        }

        public List<Student> GetAll()
        {
            return _studentCollection.getAll();
        }

        public Student Get(string firstName)
        {
         
            return _studentCollection.Get(firstName);
        }

        public Student Update(string firstName, Student student) 
        {
            return _studentCollection.Update(firstName, student);
        }

        public Student Delete(string firstName)
        {
            return _studentCollection.Delete(firstName);
        }
    }
}
