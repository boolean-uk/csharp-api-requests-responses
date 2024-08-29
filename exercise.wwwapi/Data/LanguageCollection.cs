using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language student)
        {
            _languages.Add(student);

            return student;
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language GetOne(string name)
        {
            return _languages.First(l => l.name == name);
        }

        public static Language Delete(string name)
        {

            Language deletedLanguage = _languages.First(l => l.name == name);
            _languages.Remove(deletedLanguage);

            return deletedLanguage;
        }
    }
}
