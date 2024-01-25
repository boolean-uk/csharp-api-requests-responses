using exercise.wwwapi.Models.Student;

namespace exercise.wwwapi.Repository.Interfaces
{
    public interface IStudentRepo : IRepository<Student>
    {
        public Student Add(Student item);
        public Student Update(string firstName, StudentPayload payLoad);

        public Student Get(string itemToFind);

        public Student Remove(string firstName);
    }
}
