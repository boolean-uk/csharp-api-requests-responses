using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Xml.Linq;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language>
    {
        public Language Add(Language t)
        {
            return LanguageCollection.AddLanguage(t);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

        public Language Get(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAllLanguages();
        }

        public Language Update(string name, Language lang)
        {
            return LanguageCollection.UpdateLanguage(name, lang);
        }
    }
}
