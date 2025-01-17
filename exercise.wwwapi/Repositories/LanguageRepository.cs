using System.Globalization;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository
    {

        public List<Language> Add(Language language)
        {
            LanguageCollection.Add(language);
            return LanguageCollection.GetAll();
        }
        public Language Get(string name)
        {
            return LanguageCollection.Get(name);
        }
        public List<Language> GetAll()
        {
            {
                return LanguageCollection.GetAll();
            }


        }
        public List<Language> Uppdate(string name, string newName)
        {
            LanguageCollection.Uppdate(name, newName);
            return LanguageCollection.GetAll();

        }
        public List<Language> Delete(string name)
        {
            LanguageCollection.Delete( name);
            return LanguageCollection.GetAll();
        }
    }
}
