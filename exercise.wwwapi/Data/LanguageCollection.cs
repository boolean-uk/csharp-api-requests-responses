using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#"),
            new Language("Arnold C"),
            new Language("Talk to the hand")
        };

        public static Language AddLanguage(Language language)
        {
            languages.Add(language);
            return language;
        }

        public static List<Language> GetLanguages() 
        {
            return languages; 
        }

        public static Language GetLanguage(string languageName)
        {
            var match = languages.FirstOrDefault(x => x.Name.ToLower() == languageName.ToLower());
            return match;
        }

        public static Language UpdateLanguage(string name, Language language)
        {
            var match = languages.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            match.Name = language.Name;
            return match;
        }

        public static Language DeleteLanguage(string name)
        {
            var match = languages.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            languages.Remove(match);
            return match;
        }
    }
}
