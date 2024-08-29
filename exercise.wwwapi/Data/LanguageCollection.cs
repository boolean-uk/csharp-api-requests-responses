using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };


        public static List<Language> Languages { get { return languages; } }

        public static Language AddLanguage (Language language)
        {
            languages.Add(language);
            return language;
        }

        public static Language UppdateLanguage(string name, string newName)
        {
             languages.FirstOrDefault(x => x.Name.Equals(name)).Name = newName;
            return languages.FirstOrDefault(x => x.Name.Equals(newName));
        }

        public static Language removeLanguage(Language s)
        {
            if (languages.Remove(s))
            {
                return s;
            }
            return null;
        }

    }
}
