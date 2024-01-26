using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class DataCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language() {Name="Java"},
            new Language() {Name="C#"}
        };

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.Name == name);
        }

        public Language UpdateLanguage(string name, Language updatedLanguage)
        {
            var existingLanguage = _languages.FirstOrDefault(x => x.Name == name);

            if (existingLanguage != null)
            {
                existingLanguage.Name = updatedLanguage.Name;
                return existingLanguage;
            }

            return null; // Language not found
        }

        public Language DeleteLanguage(string name)
        {
            var languageToRemove = _languages.FirstOrDefault(x => x.Name == name);

            if (languageToRemove != null)
            {
                _languages.Remove(languageToRemove);
                return languageToRemove;
            }

            return null; // Language not found
        }


        /*-----Student----*/
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students.ToList();
        }

        public Student GetStudent(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName.ToLower() == firstName.ToLower());
        }

        public Student UpdateStudent(string firstName, Student updatedStudent)
        {
            var existingStudent = GetStudent(firstName);

            if (existingStudent == null)
            {
                return null; // Student with the provided first name not found
            }

            // Update the details of the existing student
            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;

            return existingStudent;
        }

        public Student DeleteStudent(string firstName)
        {
            var studentToRemove = GetStudent(firstName);

            if (studentToRemove == null)
            {
                return null; // Student with the provided first name not found
            }

            // Remove the student from the list
            _students.Remove(studentToRemove);

            return studentToRemove;
        }

        public Student AddStudent(Student student)
        {
            _students.Add(student);

            return student;
        }
    }
}
