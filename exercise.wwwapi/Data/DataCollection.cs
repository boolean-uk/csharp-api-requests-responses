using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {

        private static List<Language> _languages = new List<Language>(){
            new Language(){Name="Java" },
            new Language(){Name="C#"}
        };

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public List<Language> GetAllLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            return _languages.Where(lang => lang.Name.Equals(name)).FirstOrDefault();
        }

        public Language UpdateLanguage(string name, Language language)
        {
            var updating = _languages.FirstOrDefault(lang => lang.Equals(language));
            language.Name = name;
            return updating;
        }

        public Language DeleteLanguage(string name)
        {
            var language = _languages.FirstOrDefault(lang => lang.Name.Equals(name));
            _languages.Remove(language);
            return language;
        }

        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student AddStudent(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            var updating = _students.FirstOrDefault(s => s.FirstName.Equals(student));
            student.FirstName = firstName;
            return updating;
        }

        public Student DeleteStudent(string firstName)
        {
            var removing = _students.FirstOrDefault(s => s.FirstName.Equals(firstName));
            _students.Remove(removing);
            return removing;
        }
    };


}
