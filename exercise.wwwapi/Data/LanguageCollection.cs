using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };


        public List<Language> getAll()
        {
            return languages;
        }

        internal bool Delete(Language lang)
        {
            bool res = languages.Remove(lang);
            return res;
        }
        internal Language Add(Language lang)
        {
            languages.Add(lang);
            return lang;
        }
    }
}
