using exercise.wwwapi.Models;
using System.Net.NetworkInformation;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
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

        public static List<Language> GetLanguages() 
        { 
            return languages.ToList(); 
        }

        public static Language GetLanguage(string name)
        {
            return languages.FirstOrDefault(x => x.name == name);
        }

        public static Language Update(string name, Language newLanguage)
        {
            Language language = languages.FirstOrDefault(x => x.name == name);

            language.name = newLanguage.name;

            return language;
        }

        public static void Delete(string name)
        {
            Language language = languages.FirstOrDefault(x => x.name == name);
            languages.Remove(language);
            Console.WriteLine("Language removed!");
        }
    }
}
