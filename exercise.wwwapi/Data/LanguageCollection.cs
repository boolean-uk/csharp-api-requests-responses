using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language() {Name = "Java"},
            new Language() {Name = "c#"}
        };



        public List<Language> getAllLanguages()
        {
            return languages;
        }

        public Language AddLanguage(LanguagePostPayload payload)
        {
            var language = new Language() { Name = payload.name };
            languages.Add(language);
            return language;
        }

        public Language getLanguageByName(string name) { 
            return languages.Find(l => l.Name.Equals(name));
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
