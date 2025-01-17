using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        public IEnumerable<Language> GetLanguages()
        {
            return LanguageCollection.Languages;
        }
        public Language GetLanguage(string name)
        {
            return LanguageCollection.Get(name);
        }
        public Language AddLanguage(Language entity)
        {
            return LanguageCollection.Add(entity);
        }
        public Language UpdateLanguage(string name, Language entity)
        { 
            return LanguageCollection.Update(name, entity); 
        }
        public bool Delete(string name)
        {
            return LanguageCollection.Remove(name);
        }
    }
}
