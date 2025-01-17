using exercise.wwwapi.Data;
using exercise.wwwapi.Models;


namespace exercise.wwwapi.Repository
{
    public class LanguageRepository<T>: IRepository<T> where T : Language
    {
        private LanguageCollection _languageCollection;

        public LanguageRepository(LanguageCollection LanguageCollection)
        {
            _languageCollection = LanguageCollection;
        }

        public T AddEntity(T entity)
        {
            _languageCollection.Add(entity);
            return entity;
        }

        public T DeleteEntity(string name)
        {
            return (T)_languageCollection.Delete(name);
        }

        public List<T> GetCollection()
        {

            return _languageCollection.getAll().Cast<T>().ToList();


        }

        public T GetEntity(string name)
        {
            return (T)_languageCollection.GetLanguage(name);
        }

        public T UpdateEntity(string name, string newname)
        {
            return (T)_languageCollection.UpdateLanguage(name, newname);
        }

        public T UpdateEntity(string name, string newfirstname, string newlastname)
        {
            throw new NotImplementedException();
        }
    }
}
