using exercise.wwwapi.Models;
using System.Security.Cryptography.X509Certificates;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static List<Language> Languages { get { return _languages; } }

        public static Language Create(Language language)
        {
            _languages.Add(language);
            return language;
        }
        public static List<Language> GetAll()
        {

            return _languages;
        }
        public static Language GetSingleLanguage(string name)
        {
            return _languages.Find(x => x.name == name);
        }
        public static Language UpdateLanguage(string name, Language language)
        {

            int index = _languages.FindIndex(language => language.name == name);

            _languages[index] = language;

            return language;

        }
        public static Language DeleteLanguage(string name)
        {

            var deletedlanguage = _languages.FirstOrDefault(x => x.name == name);
            _languages.Remove(deletedlanguage);
            return deletedlanguage;
        }
    }
        }

