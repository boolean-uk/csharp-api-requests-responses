using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };
        public Language AddLanguage(string name)
        {
            Language tempLanguage = new Language(name);
            _languages.Add(tempLanguage);
            return tempLanguage;
        }
        public List<Language> GetAll()
        {
            return _languages.ToList();
        }
        public Language? GetLanguage(string name)
        {
            return _languages.FirstOrDefault(t => t.Name == name);
        }
        public Language? RemoveLanguage(Language language)
        {
            _languages.Remove(language);
            return language;
        }
    }
}
