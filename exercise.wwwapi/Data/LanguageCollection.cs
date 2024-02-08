using exercise.wwwapi.Models.Language;

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
            return languages.ToList();
        }

        public Language? Get(string languageName)
        {
            if (languages.FirstOrDefault(l => l.getName() == languageName) == null) { return null; }
            else
            {
                var language = languages.FirstOrDefault(l => l.getName() == languageName);
                return language;

            }
        }

        public Language Update(string languageName, LanguagePayLoad languagePayload)
        {
            if (string.IsNullOrWhiteSpace(languagePayload.languageName)) { return null; }

            var language = Get(languageName);
            if (language == null) { return null; }

            language.updateName(languagePayload.languageName);
            return language;
        }

        public Language Remove(Language language)
        {
            var lang = languages.FirstOrDefault(l => l.Equals(language));
            if (!languages.Remove(lang))
            {
                return null;
            }
            else
            {
                languages.Remove(lang);
                return lang;
            }
        }
    }
}
