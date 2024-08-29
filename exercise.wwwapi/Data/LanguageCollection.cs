using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language AddLanguage(Language language)
        {
            languages.Add(language);
            return language;
        }
    }
}
