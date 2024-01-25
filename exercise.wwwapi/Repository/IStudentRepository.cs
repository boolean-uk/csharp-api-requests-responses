using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {

        public Student Create(Student model);

        public Student Delete(string input);

        public Student Get(string inputString);

        public IEnumerable<Student> GetList();

        public Student Update(string input);
    }
}
