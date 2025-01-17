using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository :ILanguageRepository
    {
        private T? validateNotNull<T>(T? val, ref bool fail)
        {
            if (val == null)
                fail = true;
            return val;
        }
        private bool ViewToLanguage(LanguageView languageView, ref Language language)
        {
            bool fail = false;
            language.name = languageView.name ?? validateNotNull(language.name, ref fail);
            return !fail;
        }
        public Language? AddLanguage(LanguageView languageview)
        {
            var language = new Language();
            if (ViewToLanguage(languageview, ref language))
                return LanguageCollection.Add(language);

            return null;
        }

        public bool DeleteLanguage(string name)
        {

            return LanguageCollection.Remove(name) != null;
        }

        public Language? GetLanguage(string name)
        {
            List<Language> languageWithSameName = new();
            if (LanguageCollection.GetLanguage(name, out languageWithSameName))
            {
                // If multiple with same name, pick first...
                return languageWithSameName.First();
            }

            return null;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return LanguageCollection.getAll();
        }

        public Language? UpdateLanguage(string name, LanguageView languageView)
        {
            Language stud = LanguageCollection.Remove(name);
            if (stud == null)
                return null;

            if (ViewToLanguage(languageView, ref stud))
                stud = LanguageCollection.Add(stud);

            return stud;

        }
    }
}
