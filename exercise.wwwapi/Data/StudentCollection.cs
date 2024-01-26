using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student(){ Id = 1,  FirstName="Adam", LastName= "Gården"},
            new Student(){ Id = 2,  FirstName="Gordon", LastName= "Ramsy"},
        };


        // add or create a student
        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }


        // get all the students
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        // get a student
        public bool GetStudent(int id, out Student student)
        {
            student = _students.FirstOrDefault(student => student.Id == id);

            if (student == null)
            {
                return false;
            }

            return true;
        }


        // update a student
        public Student UpdateStudent(int id,StudentPut student)
        {
            var target = _students.FirstOrDefault(student => student.Id == id);
            target.FirstName = student.FirstName;
            target.LastName = student.LastName;
            return target;
        }

        // delete a student
        public bool DeleteStudent(int id)
        {
            var index = _students.FindIndex(student => student.Id == id);
            if (index == -1)
                return false;

            _students.RemoveAt(index);
            return true;
        }
    
    }
}