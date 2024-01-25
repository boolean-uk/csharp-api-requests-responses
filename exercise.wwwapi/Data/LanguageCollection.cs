using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection : ILanguage
    {
        private List<Language> languages = new List<Language>(){
            new(){ Id = 1, name = "Java"},
            new(){ Id = 2, name =  "C#"}
        };


        public Language AddLanguage(Language language)
        {
            languages.Add(language);
            return language;
        }

        public bool DeleteLanguage(int id)
        {

            var languageToRemove = languages.FirstOrDefault(s => s.Id == id);
            if (languageToRemove != null)
            {
                languages.Remove(languageToRemove);
                return true;
            }
            return false;
        }

        public bool GetLanguage(int id, out Language language)
        {
            language = languages.FirstOrDefault(language => language.Id == id);
            if (language == null)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return languages;
        }


        public Language UpdateLanguage(int id, LanguagePut language)
        {
            var target = languages.FirstOrDefault(language => language.Id == id);
            target.name = language.name;
            return target;
        }
    }
}
