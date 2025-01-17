using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = [];

        public static void Initialize()
        {
            _languages.AddRange([
                new Language { Id = 1, Name = "Java" },
                new Language { Id = 2, Name = "C#" }
            ]);
        }
        public static List<Language> Languages { get { return [.._languages]; } }
        public static Language Add(Language language)
        {
            _languages.Add(language);
            return language;
        }
        public static bool Remove(Language language)
        {
            return _languages.Remove(language);
        }
    }
}
