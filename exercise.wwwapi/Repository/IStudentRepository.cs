using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        public Student Create(Student student);
        public Student Get(string firstName);

        public List<Student> GetAll();
        public Student Update(string firstName, Student student);
        public Student Delete(string firstName);


    }
}
