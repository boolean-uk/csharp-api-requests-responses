using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
namespace exercise.wwwapi.Data
{
    public class LanguageCollection
    {

        private List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };


        public List<Language> GetLangs()
        {
            return _languages;
        }

        public Language AddLang(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public Language GetLang(string name)
        {
            return _languages.FirstOrDefault(l => l.Name == name);
        }
        public Language UpdateLang(string name, Language language)
        {
            Language existingLanguage = _languages.FirstOrDefault( l => l.Name == name);

            existingLanguage.Name = language.Name;
            return language;
        }
        public Language DeleteLang(string name)
        {
            Language language = _languages.FirstOrDefault(s => s.Name == name);
            _languages.Remove(language);        
            return language;
        }

    }
}
