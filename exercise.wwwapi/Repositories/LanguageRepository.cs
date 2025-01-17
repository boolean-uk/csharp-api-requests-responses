using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repositories.Interfaces;

namespace exercise.wwwapi.Repositories
{
    public class LanguageRepository : IGenericRepository<Language>
    {
        public Language Add(Language entity)
        {
            entity.Id = LanguageCollection.Languages.Max(x => x.Id) + 1;
            LanguageCollection.Add(entity);
            return entity;
        }

        public bool Delete(int id)
        {
            Language Language = Get(id);
            return LanguageCollection.Remove(Language);
        }

        public Language Get(int id)
        {
            Language Language = LanguageCollection.Languages.FirstOrDefault(x => x.Id == id);
            return Language ?? throw new ArgumentException("That ID does not exist!");
        }

        public Language Get(Func<Language, bool> condition)
        {
            Language Language = LanguageCollection.Languages.Where(condition).FirstOrDefault();
            return Language ?? throw new ArgumentException("No Language fit that condition!");
        }

        public IEnumerable<Language> GetAll()
        {
            return LanguageCollection.Languages;
        }

        public Language Update(int id, Language entity)
        {
            Language Language = Get(id);
            Language.Name = entity.Name ?? Language.Name;
            return Language;
        }
    }
}
