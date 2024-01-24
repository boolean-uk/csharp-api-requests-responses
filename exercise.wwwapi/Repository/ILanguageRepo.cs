using exercise.wwwapi.Models.Language;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepo : IRepository<Language>
    {
        public Language Update(string firstName, LanguagePayload payLoad);
    }
}
