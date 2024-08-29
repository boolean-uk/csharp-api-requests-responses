using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> _languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static Language Add(Language entity)
        {
            var entityExists = _languages.FirstOrDefault(x => x.Name.Equals(entity.Name));
            if (entityExists is not null)
            {
                return null;
            }
            _languages.Add(entity);
            return entity;
        }

        public static List<Language> GetAll()
        {
            return _languages.ToList();
        }

        public static Language Get(string name)
        {
            return _languages.FirstOrDefault(x => x.Name == name);
        }

        public static Language Update(string name, Language entity)
        {
            var index = _languages.FindIndex(x => x.Name == name);
            if (index == -1)
            {
                return null;
            }

            _languages[index] = entity;
            return entity;
        }

        public static Language Delete(string name)
        {
            var foundEntity = _languages.FirstOrDefault(x => x.Name == name);
            if (foundEntity is null)
            {
                return null;
            }

            _languages.Remove(foundEntity);
            return foundEntity;
        }
    }
}
