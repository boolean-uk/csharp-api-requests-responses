using exercise.wwwapi.Models.Student;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepo : IRepository<Student>
    {
        public Student Update(string firstName, StudentPayload payLoad);
    }
}
