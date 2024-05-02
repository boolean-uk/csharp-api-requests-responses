using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Data
{
    public class LanguageCollection
    {
        public List<Language> Languages { get; set; }
        private int _languageId = 0;

        /*
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };
        */

        public LanguageCollection()
        {
            Languages = new List<Language>();
            AddLanguage("Java");
            AddLanguage("C#");
        }
        public Language AddLanguage(string name)
        {
            _languageId++;
            var newLanguage = new Language(_languageId, name);
            Languages.Add(newLanguage);
            return newLanguage;
        }

        public Language? GetLanguage(string name)
        {
            return Languages.FirstOrDefault(l => l.Name == name);
        }

        public Language DeleteLanguage(string name)
        {
            var languageDel = GetLanguage(name);
            return Languages.Remove(languageDel) ? languageDel : null;
        }

    }
}
