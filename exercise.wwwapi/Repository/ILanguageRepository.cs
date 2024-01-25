using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    
        public interface ILanguageRepository
        {
        IEnumerable<Language> GetList();
        Language Get(string inputString);

        Language Create(Language model);
        Language Update(string input);
        Language Delete(string input);
    
    }

}
