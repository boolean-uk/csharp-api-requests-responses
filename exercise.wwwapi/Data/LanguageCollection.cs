using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new()
        {
            new Language("Java"),
            new Language("C#")
        };
        
        public static Language Add(Language language)
        {            
            _languages.Add(language);
            return language;
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }
        
        public static Language Remove(Language language)
        {
            _languages.Remove(language);
            return language;
        }
    }
}
