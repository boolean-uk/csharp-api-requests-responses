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

        public Language getALanguage(string inputlanguage)
        {
            Language language = languages.Where(language => language.name == inputlanguage).FirstOrDefault();
            if (language == null)
            {
                return null;
            }
            return language;
        }

        public Language updateLanguage(string inputlanguage, string newName)
        {
            Language langauge = languages.Where(language => language.name == inputlanguage ).FirstOrDefault();
            if (langauge == null)
            {
                return null;
            }
            langauge.name = newName;
            return langauge;
        }

        public Language deleteLanguage(string inputlanguage)
        {
            Language student = languages.Where(language => language.name == inputlanguage).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            languages.Remove(student);
            return student;
        }
    }
}
