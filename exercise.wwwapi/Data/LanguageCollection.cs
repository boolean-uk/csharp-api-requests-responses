using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : ILanguageData
    {
        private List<Language> _languages = new List<Language>()
        {
            new Language() { Name="C#" },
            new Language() { Name="Java" }
        };

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.ToList();
        }

        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }
        public Language UpdateLanguage(string name, Language language)
        {
            var target = _languages.FirstOrDefault(language => language.Name == name);
            target.Name = language.Name;
            return target;
        }
        public Language DeleteLanguage(string name, out Language language)
        {
            language = _languages.FirstOrDefault(x => x.Name == name);
            _languages.Remove(language);
            return language;
        }

        public bool GetLanguage(string name, out Language language)
        {
            language = _languages.FirstOrDefault(x => x.Name == name);
            if (language == null)
            {
                return false;
            }
            return true;
        }
    };
    }

