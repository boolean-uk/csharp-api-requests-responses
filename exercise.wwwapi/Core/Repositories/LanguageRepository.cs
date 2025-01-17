using exercise.wwwapi.Core.Data;
using exercise.wwwapi.Core.Models;
using exercise.wwwapi.Extension.Books.Model;

namespace exercise.wwwapi.Core.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LanguageCollection _languageCollection;

        public LanguageRepository()
        {
            _languageCollection = new LanguageCollection(); // Initialize the student collection
        }

        public Language AddLanguage(Language language)
        {
            return _languageCollection.Add(language);
        }

        public Language GetSingleLanguage(string name)
        {
            return _languageCollection.getAll().FirstOrDefault(language => language.name.Equals(name));
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languageCollection.getAll();
        }

        public bool UpdateLanguage(string name, Language updatedLanguage)
        {
            var language = _languageCollection.getAll().FirstOrDefault(language => language.name.Equals(name));
            if (language != null)
            {
                language.name = updatedLanguage.name;
                return true;
            }
            return false;
        }

        public bool DeleteLanguage(string name)
        {
            var language = _languageCollection.getAll().FirstOrDefault(language => language.name.Equals(name));
            if (language != null)
            {
                _languageCollection.Remove(language.name);
                return true;
            }
            return false;
        }
    }
}
