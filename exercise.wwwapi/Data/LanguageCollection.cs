using System.Collections.Generic;
using System.Linq;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class LanguageCollection : IColl<Language>
    {
        private List<Language> _languages = new List<Language>()
        {
            new Language("Java"),
            new Language("C#")
        };

        public Language Add(Language entity)
        {
            _languages.Add(entity);
            return entity;
        }

        // Implement GetAll to satisfy IColl<Language>
        public IEnumerable<Language> GetAll()
        {
            return _languages;
        }

        // Implement GetById to satisfy IColl<Language>, using language name as id
        public Language GetById(object id)
        {
            string languageName = id.ToString();
            return _languages.FirstOrDefault(l => l.GetName() == languageName);
        }

        public Language Remove(object id)
        {
            var language = GetById(id);
            if (language != null)
            {
                _languages.Remove(language);
            }
            return language;
        }

        public Language Update(Language entity)
        {
            var language = GetById(entity.GetName());
            if (language != null)
            {
                language.SetName(entity.GetName());
            }
            return language;
        }

        public Language Update(object id, Language entity)
        {
            var language = GetById(id);
            if (language != null)
            {
                language.SetName(entity.GetName());
            }
            return language;
        }
    }
}
