using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Repository.Interfaces
{
    public interface ILanguageRepo : IRepository<Language>
    {
        public Language Add(Language item);
        public Language Update(string firstName, LanguagePayLoad payLoad);

        public Language Get(string itemToFind);
        public Language Remove(string firstName);
    }
}
