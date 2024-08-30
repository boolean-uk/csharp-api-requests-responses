using exercise.wwwapi.Models;
using System.Reflection.Metadata.Ecma335;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> Languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetAll() => Languages.ToList();

        public Language GetA(string name)
        {
            Language language = Languages.FirstOrDefault(x => x.Name == name);
            return language;
        }

        public Language Update(string name) 
        {
            var language = Languages.First();
            Languages.Remove(language);
            language.Name = name;
            Languages.Add(language);
            return language;
        }

        public Language Delete(string name)
        {
            var language = GetLanguage(name);
            Languages.Remove(language);
            return language;
        }
    }
}
