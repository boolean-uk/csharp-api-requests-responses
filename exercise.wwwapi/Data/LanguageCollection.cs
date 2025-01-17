using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>();

        public static void Initialize()
        {
            _languages.Add(new Language(){name="Java"});
            _languages.Add(new Language(){name="C#"});
        }
        public static Language Add(Language language)
        {            
            _languages.Add(language);

            return language;
        }

        public static List<Language> GetAll()
        {
            return _languages;
        }

        public static Language GetLanguage(string name)
        {
            return _languages.FirstOrDefault(x => x.name == name);
        }

        public static bool DeleteLanguage(string name)
        {
            var student = _languages.FirstOrDefault(x => x.name == name);
            if (student == null)
            {
                return false;
            }
            _languages.Remove(student);
            return true;
        }

        public static Language UpdateLanguage(string name, Language language)
        {
            var existingLanguage = _languages.FirstOrDefault(x => x.name == name);
            if (existingLanguage == null)
            {
                return null;
            }
            existingLanguage = language;
            return existingLanguage;
        }
    };
    }
