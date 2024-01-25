using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Repository
{
    public class Repository2 : IRepository2
    {

        //*********************************************************//
        public ILanguage _languageDatabase;

        public Repository2(ILanguage languageDatabase)
        {
            _languageDatabase = languageDatabase;

        }
        public IEnumerable<Language> GetLanguages()
        {
            return _languageDatabase.GetLanguages();
        }

        public Language AddLanguage(Language language)
        {
            return _languageDatabase.AddLanguage(language);
        }

        public Language UpdateLanguage(int id, LanguagePut languagePut)
        {
            // Attempt to retrieve the language with the given ID
            var found = _languageDatabase.GetLanguage(id, out Language language);

            // If the language is not found, return null
            if (!found)
            {
                return null;
            }

            // Update the language name with the provided value
            language.name = languagePut.name;

            // Save changes (if applicable) - This depends on your implementation

            return language;
        }


        public bool DeleteLanguage(int id)
        {
            return _languageDatabase.DeleteLanguage(id);
        }


    }

}
