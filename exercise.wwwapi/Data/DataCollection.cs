using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        private static List<Language> _languages = new List<Language>(){
            new Language() { name ="Java"},
            new Language() { name ="C#"}
        };

        public Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public List<Student> getAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.Find(x => x.FirstName == firstName);
        }

        public Student DeleteStudent(string FirstName)
        {
            Student student = GetStudent(FirstName);
            _students.Remove(GetStudent(FirstName));
            return student;
        }

        public Student CreateStudent(string firstName, string lastName)
        {
            _students.Add(new Student() { FirstName = firstName, LastName = lastName });
            return GetStudent(firstName);
        }

        public Student UpdateStudent(string FirstName, string NewFirstName)
        {
            Student stud = GetStudent(FirstName);
            stud.FirstName = NewFirstName;
            return stud;
        }

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public List<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language GetLanguage(string languageName)
        {
            return _languages.Find(x => x.name == languageName);
        }
        public Language CreateLanguage(string language)
        {
            _languages.Add(new Language() { name = language });
            return GetLanguage(language);
        }
        public Language UpdateLanguage(string languageName, string newLanguage)
        {
            Language lang = GetLanguage(languageName);
            lang.name = newLanguage;
            return lang;
        }

        public Language DeleteLanguage(string languageName)
        {
            Language lang = GetLanguage(languageName);
            _languages.Remove(lang);
            return lang;
        }


    }
}
