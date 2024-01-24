using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>() {
            new Language("Java"),
            new Language("C#")
        };

        public Language Create(Language language)
        {
            _languages.Add(language);

            return language;
        }

        public bool Delete(string language)
        {
            Language lang = _languages.Find(x => x.Name == language);
            
            return _languages.Remove(lang);
        }

        public List<Language> GetAll()
        {
            return _languages;
        }

        public Language Get(string language)
        {
            return _languages.Find(x => x.Name.ToLower().Contains(language.ToLower()));
        }

        public Language Update(string language, string newLanguage)
        {
            Language lang = Get(language);
            if(lang == null || lang == default(Language))
                return lang;
            
            lang.Name = newLanguage;
            return lang;
        }
    }
}
