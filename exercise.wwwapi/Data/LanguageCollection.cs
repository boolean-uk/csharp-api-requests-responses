using exercise.wwwapi.Models;
using System.Collections.ObjectModel;

namespace exercise.wwwapi.Data
{

    public class LanguageCollection:ILanguageDB
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public List<Language> GetObjects()
        {
            List<Language> list = new List<Language>();
            _languages.ForEach(x => list.Add(x));
            return GetObjects(list);
        }

        public List<Language> GetObjects(List<Language> languages)
        {
            List<Language> list = new List<Language>();
            list = languages;
            return list;
        }
        public Language CreateObject(Language newLanguage)
        {
            _languages.Add((Language)newLanguage);
            return newLanguage;

        }
        public Language UpdateObject(string input)
            {
                Language language = _languages.First();
            language.Name = input;
                return language;
            }



            public Language DeleteObject(string input)
            {
                Language DeletedLanguage = _languages.FirstOrDefault(x => x.Name == input);
            _languages.Remove(DeletedLanguage);
                return DeletedLanguage;
            }


            
    }
}
