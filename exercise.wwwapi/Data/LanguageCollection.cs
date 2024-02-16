using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> Languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };
        public Language AddLanguage(LanguageCreatePayload languageData)
        {
            var newLanguage = new Language(languageData.Name);
            Languages.Add(newLanguage);
            return newLanguage;
        }

        public List<Language> GetAll()
        {
            return Languages;
        }
        public Language GetLanguage(string name)
        {
            return Languages.FirstOrDefault(l => l.Name == name);
        }

        public Language UpdateLanguage(string name, LanguageUpdatePayload languageData)
        {
            var language = GetLanguage(name);
            if (language == null)
            {
                return null;
            }
            language.Name = languageData.Name ?? language.Name;
            return language;
        }

        public Language DeleteLanguage(string name)
        {
            var language = GetLanguage(name);
            return Languages.Remove(language) ? language : null;
        }
    }
}
