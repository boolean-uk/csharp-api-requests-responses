using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetAll()
        {
            return languages.ToList();
        }

        public Language GetALanguage(string language)
        {
            return languages.FirstOrDefault(l => l.GetName() == language);
        }

        public Language Add(Language language)
        {
            languages.Add(language);
            return language;
        }

        public Language Remove(Language language)
        {
            languages.Remove(language);
            return language;
        }
    }
}
