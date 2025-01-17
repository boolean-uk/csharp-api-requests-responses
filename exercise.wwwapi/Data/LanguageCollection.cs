using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public static class LanguageCollection
    {
        private static List<Language> languages = new List<Language>(){
            new Language("Java"),
            new Language("C#")
        };

        public static List<Language>  GetLanguages()
        {
            return languages;
        }

        public static Language GetLanguage(string name)
        {
            return languages.FirstOrDefault(l => l.Name == name);
        }

        public static Language AddLanguage(string name)
        {
            if (languages.FirstOrDefault(l => l.Name == name) != null)
            {
                return null; //Language already exitst!
            }

            Language newLanguage = new Language(name);
            languages.Add(newLanguage);
            return newLanguage;

        }

        public static Language UpdateLanguage(string currentName, string newName)
        {
            try
            {
                
                Language toUpdate = languages.FirstOrDefault(l => l.Name == currentName);
                languages.Remove(toUpdate);
                Language newLanguage = new Language(newName);
                languages.Add(newLanguage);
                return newLanguage;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Language DeleteLanguage(string name)
        {
            return languages.RemoveAll(l => l.Name == name) > 0 ? new Language(name) : null;
        } 


    }


}
