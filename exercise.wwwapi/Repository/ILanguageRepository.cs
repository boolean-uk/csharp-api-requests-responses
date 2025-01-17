using System;
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface ILanguageRepository
{

    public IEnumerable<Language> GetLanguages();

    public Language GetLanguage(string name);

    public Language AddLanguage(string name);
    public Language UpdateLanguage(string currentName, string newName);
    public Language DeleteLanguage(string name);

}
