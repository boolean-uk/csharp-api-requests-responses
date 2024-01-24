using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };



        public List<Language> getAllLanguages()
        {
            return languages.ToList();
        }

        public Language AddLanguage(LanguagePostPayload payload)
        {
            var language = new Language(payload.name);
            languages.Add(language);
            return language;
        }

        public Language getLanguageByName(string name) { 
            return languages.Find(l => l.getName().Equals(name));
        }

        public void deteleLanguageByName(string name)
        {
            var language = getLanguageByName(name);
            if (language != null)
            {
                languages.Remove(language);
            } else
            {
                throw new Exception("No such language");
            }
        }
    }
}
