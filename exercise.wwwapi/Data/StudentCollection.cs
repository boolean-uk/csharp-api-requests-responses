using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student student) //Add the given student to the list
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll() //Get all students in the list
        {
            return _students;
        }

        public static Student Get(string firstName) //Get a student with this first name from the list
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            return student;
        }

        public static Student Remove(string firstName) //Remove a student with this first name from the list
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            _students.Remove(student);
            return student;
        }

        public static Student Update(Student newStudent, string firstName) //Replace the student that has the given first name with the new student
        {
            int index = _students.IndexOf(_students.FirstOrDefault(x => x.FirstName == firstName));
            if (index != -1)
            {
                _students[index] = newStudent;
            }
            return _students[index];
        }
    };


}
