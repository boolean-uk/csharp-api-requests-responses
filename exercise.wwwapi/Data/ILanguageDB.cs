using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ILanguageDB
    {
        List<Language> GetObjects();
        Language CreateObject(Language model);
        Language UpdateObject(string input);

        Language DeleteObject(string input);
        
    }
}
