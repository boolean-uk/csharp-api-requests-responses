using exercise.wwwapi.Models;


namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(StudentPostPayload payload)
        {
            var newStudent = new Student() { FirstName = payload.firstname, LastName = payload.lastname};
            _students.Add(newStudent);

            return newStudent;
        }

        public List<Student> getAll()
        {
            return _students;
        }

        public Student getStudentByName(string firstname)
        {
            return _students.Find(x => x.FirstName == firstname);
        }

        public bool deleteStudentByName(string firstname)
        {
            var deleteStudent = getStudentByName(firstname);
            if (deleteStudent != null)
            {
                _students.Remove(deleteStudent);
                return true;
            } else
            {
                throw new Exception("No such Student");
            }
            
        }

        
    };


}
