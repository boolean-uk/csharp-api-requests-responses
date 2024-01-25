using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetLanguages() 
        {
            return languages;
        }

        public Language AddLanguage(Language language) 
        {
            // Maintain a unique list, no point having duplicates
            if (languages.Where(lang => lang.Name == language.Name).FirstOrDefault() == null) 
            {
                languages.Add(language);
            }

            return language;
        }

        public void RemoveLanguage(Language language) 
        {
            languages.Remove(language);
        }
    }
}
