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

        public static Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students;
        }

        public static Student GetStudentByFirstName(string firstName)
        {
            foreach (Student student in _students)
            {
                if (student.FirstName.ToLower() == firstName.ToLower())
                {
                    
                    return student;
                }
            }


            return null;
        }

        public static Student UpdateStudentInfo(string firstname , string newFirstName, string newLastName)
        {
            Student student = GetStudentByFirstName(firstname);
            if (student!= null)
            {
                student.FirstName = newFirstName;
                student.LastName = newLastName;
                return student;
            }

            return null;
        }

        public static Student DeleteStudent(string firstname)
        {
            Student student = GetStudentByFirstName(firstname);
            Student removedStudent;
            if (student != null)
            {
                removedStudent = student;
                _students.Remove(student);
                return removedStudent;
            }

            return null;
        }


    }
}
