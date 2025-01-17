using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static List<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public static Language GetLanguage(string languageName)
        {
            return _languages.Find(x => x.Name.Equals(languageName, StringComparison.CurrentCultureIgnoreCase));
        }
        public static Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public static Language UpdateLanguage(Language language, string newName)
        {
            var LanguageToUpdate = _languages.Find(x => x.Name.Equals(newName, StringComparison.CurrentCultureIgnoreCase));
            LanguageToUpdate.Name = language.Name;

            return LanguageToUpdate;
        }
        public static Language RemoveLanguage(string name)
        {
            var languageToRemove = GetLanguage(name);
            _languages.Remove(languageToRemove);

            return languageToRemove;
        }
    }
}
