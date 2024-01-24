using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students;
        public StudentCollection() {
            _students = new List<Student>();
            _students.Add(new Student("Nathan", "King"));
            _students.Add(new Student("Dave", "Ames"));
        }

        public List<Student> Students {get {return _students;}}

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public Student? get(string FirstName) {
            return _students.FirstOrDefault(t => t.FirstName == FirstName);
        }

        public Student? Remove(Student student) {
            if(student == null)
                return null;
            _students.Remove(student);
            return student;
        }
    };


}
