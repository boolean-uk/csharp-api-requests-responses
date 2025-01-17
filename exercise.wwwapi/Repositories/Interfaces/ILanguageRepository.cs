using exercise.wwwapi.Models;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories.Interfaces
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguage(string name);
        Language? AddLanguage(LanguageView student);
        Language? UpdateLanguage(string name, LanguageView studentview);
        Language? DeleteLanguage(string name);
    }
}
