using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language(){ Name = "Java" },
            new Language(){ Name = "C#" }
        };

        public static Language CreateALanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public static List<Language> GetAllLanguages()
        {
            return _languages;
        }

        public static Language GetALanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.Name == name);
        }

        public static Language UpdateLanguage(string name, string newName)
        {
            Language updatedLanguage = _languages.FirstOrDefault(x => x.Name == name);
            updatedLanguage.Name = newName;
            return updatedLanguage;

        }

        public static Language DeleteLanguage(string name)
        {
            Language deleteLanguage = _languages.FirstOrDefault(x => x.Name == name);
            _languages.Remove(deleteLanguage);

            return deleteLanguage;
        }

    }
}
