using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRespository : IRepository<Language>
    {
        public Language AddClass(Language entity)
        {
            LanguageCollection.Add(entity);
            return entity;
        }

        public List<Language> GetClasses()
        {
            return LanguageCollection.GetAll();
        }

        public Language GetClass(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public Language UpdateClass(Language newLanguage, string name)
        {
            return LanguageCollection.UpdateLanguage(newLanguage, name);
        }

        public Language DeleteClass(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }
    }
}
