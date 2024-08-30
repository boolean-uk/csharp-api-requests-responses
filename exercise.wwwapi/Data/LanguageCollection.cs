using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language AddLanguage(Language entity)
        {
            if (_languages.Any(l => l.Name == entity.Name)) return null;  // language already exists
            _languages.Add(entity);
            return entity;
        }

        public static List<Language> GetLanguages() 
        {
            return _languages.ToList(); 
        }

        public static Language GetALanguage(string name)
        {
            var language = _languages.FirstOrDefault(l => l.Name == name);
            return language;
        }

        public static Language UpdateLanguage(string name, Language entity)
        {

            var language = _languages.FirstOrDefault(s => s.Name == name);
            language = entity;
            return language;
        }

        public static Language DeleteLanguage(string firstname)
        {
            var language = _languages.Find(s => s.Name == firstname);
            _languages.Remove(language);
            return language;
        }


    }
}
