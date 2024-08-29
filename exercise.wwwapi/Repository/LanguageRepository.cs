using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public List<Language> GetAll()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language GetOne(string name)
        {
            return LanguageCollection.GetALanguage(name);

        }

        public Language Add(Language entity)
        {
            LanguageCollection.AddLanguage(entity);
            return entity;
        }

        public Language Update(string name, string updatedName)
        {
            return LanguageCollection.UpdateLanguage(name, updatedName);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }


    }
}
