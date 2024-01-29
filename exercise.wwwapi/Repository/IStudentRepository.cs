using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    //interface
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public Student DeleteStudent(string firstname);

        public Student Add(string firstname, string lastname);

        public Student? GetStudentItem(string Firstname);

        public Student? UpdateStudent(string Firstname, StudentItemUpdate updateData);
    }
}
