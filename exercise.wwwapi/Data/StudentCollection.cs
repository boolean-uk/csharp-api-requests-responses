using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }
        public static Student Get(string firstname)
        {
            return _students.FirstOrDefault(student=> student.FirstName == firstname);
        }
        public static List<Student> Delete(string firstname) 
            {
                _students.RemoveAll(student => student.FirstName == firstname);
            return _students.ToList();
            }
        public static Student Uppdate(string firstname, string newFirstName, string NewLastName)
        {

            Student student = _students.FirstOrDefault(student => student.FirstName == firstname);
            student.FirstName = newFirstName;
            student.LastName = NewLastName;
            return student;
            
        }
    };


}
