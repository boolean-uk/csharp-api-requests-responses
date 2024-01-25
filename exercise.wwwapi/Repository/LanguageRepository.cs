using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using System.Linq.Expressions;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository:ILanguageRepository
    {
        private ILanguageDB _collection;

        public LanguageRepository(ILanguageDB LanguageCollection)
        {
            _collection = LanguageCollection;
        }
        public IEnumerable<Language> GetList()
        {
            List<Language> list = new List<Language>();
            list = _collection.GetObjects();
            return list;
        }
       public Language Get(string inputString)
        {

            Language language =(Language)_collection.GetObjects().FirstOrDefault(language => language.Name.ToLower().Equals(inputString.ToLower()));
           
             return language;
        }
        
        public Language Create(Language model)
        {

           return _collection.CreateObject(model);
        }
        
        public Language Update(string input)
        {
                        
            Language updatedLanguage = (Language)_collection.UpdateObject(input);
            return updatedLanguage;
        }
        
        public Language Delete(string input)
        {

            Language DeletedLanguage = (Language)_collection.DeleteObject(input);
            
            return DeletedLanguage;
        }
       
    }
}
