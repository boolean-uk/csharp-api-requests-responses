using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private T? validateNotNull<T>(T? val, ref bool fail)
        {
            if (val == null)
                fail = true;
            return val;
        }
        private bool ViewToStudent(StudentView studentView,ref Student student)
        {
            bool fail = false; 
            student.LastName  = studentView.LastName  ?? validateNotNull(student.LastName , ref fail);
            student.FirstName = studentView.FirstName ?? validateNotNull(student.FirstName, ref fail);
            return !fail;
        }
        public Student? AddStudent(StudentView studentview)
        {
            var student = new Student();
            if (ViewToStudent(studentview, ref student))
                return StudentCollection.Add(student);

            return null;
        }

        public bool DeleteStudent(string name)
        {

            return StudentCollection.Remove(name) != null;
        }

        public Student? GetStudent(string name)
        {
            List<Student> studentWithSameName = new();
            if(StudentCollection.GetStudent(name, out studentWithSameName))
            {
                // If multiple with same name, pick first...
                return studentWithSameName.First();
            }

            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.getAll();
        }

        public Student? UpdateStudent(string name, StudentView studentView)
        {
            Student stud = StudentCollection.Remove(name);
            if (stud == null)
                return null;

            if (ViewToStudent(studentView, ref stud))
                stud = StudentCollection.Add(stud);

            return stud;
            
        }
    }
}
