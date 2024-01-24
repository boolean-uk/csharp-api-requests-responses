using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language CreateLanguage(string name)
        {
            Language language = new Language(name);
            languages.Add(language);
            return language;
        }

        public List<Language> GetAllLanguages()
        {
            return languages;
        }

        public Language GetLanguageByName(string name)
        {
            return languages.FirstOrDefault(x => x.getName() == name);
        }

        public Language UpdateLanguage(string oldName, string newName)
        {
            Language language = GetLanguageByName(oldName);
            language.Update(newName);
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            Language language = GetLanguageByName(name);
            languages.Remove(language);
            return language;
        }
    }
}
