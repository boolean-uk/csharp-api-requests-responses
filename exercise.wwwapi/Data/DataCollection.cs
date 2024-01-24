using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Xml.Linq;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
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

        public List<Student> getAllStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstname)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            if (student != null)
            {
                return student;
            }
            return null;
        }

        public Student UpdateStudent(string firstname, Student newstudent)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            if (student == null)
            {
                return null;
            }
            student.FirstName = newstudent.FirstName; 
            student.LastName = newstudent.LastName;
            return student;
        }

        public Student DeleteStudent(string firstname)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstname);
            _students.RemoveAll(student => student.FirstName == firstname);
            return student;
        }


        private static List<Language> languages = new List<Language>(){
            new Language() {name = "Java"},
            new Language() {name = "C#"}
        };

        public Language AddLanguage(Language language)
        {
            languages.Add(language);

            return language;
        }

        public List<Language> getAllLanguages()
        {
            return languages.ToList();
        }

        public Language GetLanguage(string name)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            if (language == null)
            {
                return null;
            }
            return language;
        }

        public Language UpdateLanguage(string name, Language newLanguage)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            if (language == null)
            {
                return null;
            }
            language.name = newLanguage.name;
            language.name = newLanguage.name;
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            var language = languages.FirstOrDefault(language => language.name == name);
            languages.RemoveAll(language => language.name == name);
            return language;
        }

    }
}
