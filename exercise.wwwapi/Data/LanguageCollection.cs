using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language AddLanguage(string name)
        {

            var newLanguage = new Language(name);
            languages.Add(newLanguage);

            return newLanguage;
        }

        public List<Language> GetAllLanguages()
        {
            return languages.ToList();
        }

        public Language? GetLanguage(string name)
        {
            return languages.Find(s => s.name == name);
        }

        public Language? DeleteLanguage(string name)
        {
            Language lg = languages.Find(s => s.name == name);
            languages.Remove(lg);
            return lg;
        }
    }
}
