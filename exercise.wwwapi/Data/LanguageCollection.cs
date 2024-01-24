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

        public List<Language> getAll()
        {
            return languages.ToList();
        }

        public void RemoveLanguage(Language language)
        {
            languages.Remove(language);
        }

        public Language GetLanguage(string Name)
        {
            Language language = languages.Find(x => x.Name == Name);

            return language;
        }
    }
}
