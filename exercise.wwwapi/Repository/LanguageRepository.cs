using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language AddLanguage(Language language)
        {
            LanguageCollection.AddLanguage(language);
            return language;
        }

        List<LanguageRepository> ILanguageRepository.GetAllLanguages()
        {
            throw new NotImplementedException();
        }

        Language ILanguageRepository.GetLanguage(string name)
        {
            throw new NotImplementedException();
        }

        Language ILanguageRepository.UpdateLanguage(string name, string newname)
        {
            throw new NotImplementedException();
        }

        Language ILanguageRepository.DeleteLanguage(string name)
        {
            throw new NotImplementedException();
        }

        

        

        
    }
}
