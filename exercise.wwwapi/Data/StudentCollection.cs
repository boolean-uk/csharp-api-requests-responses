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

        public static Student AddStudent(Student student)
        {             
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student GetStudent(string firstName)

        {
            Console.WriteLine(firstName);
            Console.WriteLine(_students.First(x => x.FirstName == firstName));
            return _students.First(x => x.FirstName == firstName);
            
        }

        public static Student UpdateStudent(string firstName, string newFirstName, string newLastName)

        {
            Student student = GetStudent(firstName);
                if (student !=null)
                {
                    student.FirstName = newFirstName;
                    student.LastName = newLastName;
                    return student;
                }

            return null;
 
        }

        public static Student DeleteStudent(string firstName)

        {
            
            var studentToDelete = _students.FirstOrDefault(stu => stu.FirstName.Equals(firstName));

            if (studentToDelete != null)
            {
                _students.Remove(studentToDelete); 
                return studentToDelete; 
            }

            return null; 
        }
    };


}
