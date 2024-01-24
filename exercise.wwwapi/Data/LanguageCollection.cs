using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        public List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language language)
        {
            languages.Add(language);

            return language;
        }

        public List<Language> getAll()
        {
            return languages.ToList();
        }

        
    }
}
