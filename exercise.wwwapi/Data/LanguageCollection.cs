using exercise.wwwapi.Models;
using System.Reflection.Metadata.Ecma335;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> Languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static List<Language> GetAll() => Languages.ToList();

        public static Language GetA(string name)
        {
            Language language = Languages.FirstOrDefault(x => x.Name == name);
            return language;
        }
        public static Language Create(Language language)
        {
            Languages.Add(language);
            return language;
        }

        public static Language Update(string name) 
        {
            var language = Languages.First();
            Languages.Remove(language);
            language.Name = name;
            Languages.Add(language);
            return language;
        }

        public static Language Delete(string name)
        {
            var language = GetA(name);
            Languages.Remove(language);
            return language;
        }
    }
}
