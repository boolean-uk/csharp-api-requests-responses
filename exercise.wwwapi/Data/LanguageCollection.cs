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

        public List<Language> GetAll()
        {
            return languages;
        }

        public Language GetLanguage(string languageName)
        {
            return languages.FirstOrDefault(t => t.name == languageName);
        }

        public Language UpdateLanguage(string nameToUpdate, Language updatedLanguage)
        {
            var lang = GetLanguage(nameToUpdate);
            lang.name = updatedLanguage.name;

            return lang;
        }

        public Language RemoveLanguage(string  nameToRemove)
        {

            Language removeLang = new Language(nameToRemove);
            languages.Remove(removeLang);
            return removeLang;

        }
    }


}
