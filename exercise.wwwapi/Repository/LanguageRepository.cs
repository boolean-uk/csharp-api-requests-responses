using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepo<Language, string>
    {
        public Language Add(Language item)
        {
            return LanguageCollection.Add(item);
        }

        public void Delete(string str)
        {
            LanguageCollection.Delete(str);
        }

        public Language Get(string str)
        {
            return LanguageCollection.Get(str);
        }

        public List<Language> getAll()
        {
            return LanguageCollection.getAll();
        }

        public Language Update(Language item, string str)
        {
            return LanguageCollection.Update(item, str);
        }
    }
}
