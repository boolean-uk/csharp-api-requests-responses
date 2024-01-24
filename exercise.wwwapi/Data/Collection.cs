using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class Collection : ICollection
    {
        private static List<Language> _languages = new List<Language>()
        {
                new Language() { Name="Java" },
                new Language() { Name="C#" }
        };

        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string name)
        {
            return _students.FirstOrDefault(student => student.FirstName == name);
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student UpdateStudentName(string name, Student student)
        {
            var updateStudent = _students.FirstOrDefault(s => s.FirstName == name);

            if (updateStudent == null)
            {
                return null;
            }

            updateStudent.FirstName = student.FirstName;
            updateStudent.LastName = student.LastName;

            return updateStudent;
        }

        public Student DeleteStudent(string name)
        {
            var deletedStudent = _students.FirstOrDefault(student => student.FirstName == name);

            if (deletedStudent == null)
            {
                return null;
            }

            _students.Remove(deletedStudent);
            return deletedStudent;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(language => language.Name == name);
        }

        public Language AddLanguage(string name)
        {
            Language language = new Language() { Name = name };
            _languages.Add(language);
            return language;
        }

        public Language UpdateLanguage(string oldName, string newName)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == oldName);

            if (language == null)
            {
                return null;
            }

            language.Name = newName;
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name == name);

            if (language == null)
            {
                return null;
            }

            _languages.Remove(language);
            return language;
        }
    }
}
