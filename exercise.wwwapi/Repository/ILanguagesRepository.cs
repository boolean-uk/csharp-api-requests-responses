using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguagesRepository
    {
        Language AddLanguage(string name);
        Language GetALanguage(string name);
        List<Language> GetAllLanguages();
        Language RemoveLanguage(string name);
        Language UppdageLanguage(string name, string newName);
    }
}