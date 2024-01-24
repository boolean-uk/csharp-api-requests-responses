using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Student> _students =
        [
            new Student("Nathan","King"),
            new Student("Dave", "Ames" )
        ];

        public Student AddStudent(Student student)
        {
            _students.Add(student);

            return student;
        }

        public Student DeleteStudent(string firstName)
        {
            Student stud = _students.Find(x => x.FirstName == firstName);
            if (stud != null)
            {
                _students.Remove(stud);
                return stud;
            }
            return null;
        }

        public List<Student> getAllStudents()
        {
            return _students.ToList();
        }

        private static  List<Language> languages = new(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> getLanguages()
        {
            return languages.ToList();
        }
    }
}
