using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language() { name = "Java"},
            new Language() { name = "C#" }
        };

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
        public Student GetOneStudent(string firstname)
        {
            return _students.FirstOrDefault(s=>s.FirstName.ToLower()==firstname.ToLower());
        }
        public Student DeleteStudent(string firstname)
        {
            var item = GetOneStudent(firstname);
            if (item != null) { _students.Remove(item); return item; }

            return null;
        }
        public Student UpdateStudent(string firstname, Student newStudent)
        {
            var existingStudent = GetOneStudent(firstname);

            if (existingStudent == null)
            {
                return null;
            }
            existingStudent.FirstName = !string.IsNullOrEmpty(newStudent.FirstName) ? newStudent.FirstName : existingStudent.FirstName;
            existingStudent.LastName = !string.IsNullOrEmpty(newStudent.LastName) ? newStudent.LastName : existingStudent.LastName;

            return existingStudent;
        }
        public List<Language> GetAllLanguages()
        {
            return _languages.ToList();
        }
        public Language GetOneLanguage(string name)
        {
            return _languages.FirstOrDefault(x=>x.name.ToLower() == name.ToLower());
        }
        public Language UpdateLanguage(string name, Language newLanguage)
        {
            Language orgLang = GetOneLanguage(name);
            orgLang.name = newLanguage.name;
            return orgLang;
        }
        public Language DeleteLanguage(string name)
        {
            var item = GetOneLanguage(name);
            if (item != null) { _languages.Remove(item); return item; }

            return null;
        }
        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

    }

}
