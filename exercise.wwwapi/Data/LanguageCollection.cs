using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language language)
        {
            LanguageCollection._languages.Add(language);

            return language;
        }

        public static Language? Remove(string name)
        {
            Language? language = LanguageCollection._languages.ToList().Where(x => x.name == name).FirstOrDefault();

            if (language != null)
                LanguageCollection._languages.Remove(language);

            return language;
        }

        public static List<Language> getAll()
        {
            return LanguageCollection._languages.ToList();
        }


        public static bool GetLanguage(string name, out List<Language> language)
        {
            // Languages might have identical firstnames...
            language = LanguageCollection._languages.Where(x => x.name == name).ToList();
            if (language.Count == 0)
                return false;
            return true;
        }
    }
}
