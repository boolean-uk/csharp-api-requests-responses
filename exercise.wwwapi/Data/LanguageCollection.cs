using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection
    {
        private List<Language> _languages = new List<Language>(){
            new(){ Id = 1, Name = "Java"},
            new(){ Id = 2, Name =  "C#"}
        };


        public Language AddLanguage(Language language)
        {
            _languages.Add(language);
            return language;
        }

        public bool DeleteLanguage(int id)
        {

            var languageToRemove = _languages.FirstOrDefault(s => s.Id == id);
            if (languageToRemove != null)
            {
                _languages.Remove(languageToRemove);
                return true;
            }
            return false;
        }

        public bool GetLanguage(int id, out Language language)
        {
            language = _languages.FirstOrDefault(language => language.Id == id);
            if (language == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languages;  
        }


        public Language UpdateLanguage(int id, LanguagePut language)
        {
            var target = _languages.FirstOrDefault(language => language.Id == id);
            target.Name = language.Name;
            return target;
        }
    }
}
