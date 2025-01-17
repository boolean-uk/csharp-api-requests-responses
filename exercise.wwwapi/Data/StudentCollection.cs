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

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }
        public Student Delete(string name)
        {
            var Removedstudent=_students.FirstOrDefault(x=>x.FirstName==name);
            if (Removedstudent != null) { _students.Remove(Removedstudent); }
          
            return Removedstudent;
        }

        public Student GetStudent(string name)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == name);
            return student;


        }
        public Student UpdateStudent(string firstname, string newFirstName,string newLastaName )
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstname);
            student.FirstName = newFirstName;
            student.LastName = newLastaName;

            return student;


        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }
    };


}
