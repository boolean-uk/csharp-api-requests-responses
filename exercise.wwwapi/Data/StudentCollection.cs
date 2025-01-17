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
            StudentCollection._students.Add(student);

            return student;
        }
        
        public static Student? Remove(string name)
        {
            Student? student = StudentCollection._students.Where(x => x.FirstName == name).FirstOrDefault();

            if (student != null)
                StudentCollection._students.Remove(student);                

            return student;
        }

        public static List<Student> getAll()
        {
            return StudentCollection._students.ToList();
        }
        
        
        public static bool GetStudent(string name, out List<Student> student) 
        {
            // Students might have identical firstnames...
            student = StudentCollection._students.Where(x => x.FirstName == name).ToList();
            if (student.Count == 0)
                return false;
            return true;
        }
    };


}
