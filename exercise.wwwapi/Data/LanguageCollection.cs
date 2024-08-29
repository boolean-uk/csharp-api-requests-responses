using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language)
        {
            languages.Add(language);
            return language;
        }

        public static Language Get(string name)
        {
            return languages.FirstOrDefault(x => x.name == name);
        }

        public static List<Language> getAll()
        {
            return languages;
        }

        public static void Delete(string name)
        {
            Language language = languages.FirstOrDefault(x => x.name == name);
            languages.Remove(language);
        }

        public static Language Update(Language language, string name)
        {
            Language oldLanguage = languages.FirstOrDefault(x => x.name == name);
            oldLanguage.name = language.name;

            return oldLanguage;
        }



    }

    
}
