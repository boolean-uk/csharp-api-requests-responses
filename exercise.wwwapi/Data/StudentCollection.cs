using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection:IStudentDB
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddToDB(Student student)
        {            
            _students.Add(student);


            return student;
        }

        public List<Student>  GetObjects()
        {
           return _students;
        }
       
        public Student UpdateObject(string input)
        {
            Student student = _students.First();
            student.FirstName = input;
                       
            return student;
        }



        public Student DeleteObject(string input)
        {
            Student DeletedStudent = _students.FirstOrDefault(x => x.FirstName.ToLower() == input.ToLower());
            _students.Remove(DeletedStudent);
            return DeletedStudent;
        }

    };


}
