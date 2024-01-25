using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _students;
        public StudentRepository(IStudentDB studentcollection) {
            _students = (StudentCollection)studentcollection;
        }
        public Student Create(Student model)
        {
            Student student = _students.AddToDB(model);
            return student;
        }

        public Student Delete(string input)
        {
            Student DeletedStudent = _students.DeleteObject(input);

            return DeletedStudent;
        }

        public Student Get(string inputString)
        {
            Student student = _students.GetObjects().FirstOrDefault(x => x.FirstName.ToLower().Equals(inputString.ToLower()));

            return student;
        }

        public IEnumerable<Student> GetList()
        {
                      
            return _students.GetObjects(); ;
            
        }

        public Student Update(string input)
        {
           Student student = _students.UpdateObject(input);

            return student;
        }
    }
}
