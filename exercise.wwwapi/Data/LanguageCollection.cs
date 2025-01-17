using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Razor.Hosting;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };
        public static List<Language> Add(Language language)
        {
            languages.Add(language);
            return languages;
        }
        public static Language Get(string name)
        {
            return languages.FirstOrDefault(language => language.name == name);
        }
        public static List<Language> GetAll()
        {
            {
                return languages;
            }


        }
        public static List<Language> Uppdate(string name, string newName)
        {
            var language =  languages.FirstOrDefault(lang => lang.name == name);
            language.name = newName;
            return languages;

        }
        public static List<Language> Delete(string name)
        {
            languages.RemoveAll(b => b.name== name);
            return languages;
        }
    }
}
