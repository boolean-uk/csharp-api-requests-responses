using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

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

        public Language Create(string name)
        { 
            Language NewLangugae = new Language(name);
            languages.Add(NewLangugae);
            return NewLangugae;
            
        }

        public List<Language> GetAll()
        {

            return languages.ToList();
        }

    }
}
