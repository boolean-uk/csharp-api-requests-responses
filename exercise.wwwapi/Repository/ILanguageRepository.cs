using System;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository;

public interface ILanguageRepository
{
    Language AddLanguage(Language language);
    bool DeleteLanguage(string name);
    Language GetLanguage(string name);
    IEnumerable<Language> GetLanguages();
    Language UpdateLanguage(string name, Language language);
}
