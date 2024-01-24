using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language CreateLanguage(Language language) 
        {
            this.languages.Add(language);
            return language;
        }

        public List<Language> GetLanguages() 
        {
            return this.languages;
        }

        public Language GetLanguage(string name) 
        {
            Language language = this.languages.First(x => x.name == name);
            return language;
        }

        public Language Update(string name, Language language) 
        {
            Language retrievedLanguage = this.languages.First(l => l.name == name);
            retrievedLanguage.name = language.name;
            return retrievedLanguage;
        }

        public Language Delete(string name) 
        {
            Language language = this.languages.First(l => l.name == name);
            this.languages.Remove(language);
            return language;
        }
    }
}
