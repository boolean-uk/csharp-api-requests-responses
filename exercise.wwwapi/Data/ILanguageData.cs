using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ILanguageData
    {
        IEnumerable<Language> GetLanguages();
        Language AddLanguage(Language Language);
        Language UpdateLanguage(string name, Language newLanguage);
        Language DeleteLanguage (string name, out Language Language);
        bool GetLanguage(string name, out Language Language);
    }
}
