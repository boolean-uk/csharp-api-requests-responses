
using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Data
{
    public interface ILanguage
    {
        IEnumerable<Language> GetLanguages();
        Language AddLanguage(Language language);
        Language UpdateLanguage(int id, LanguagePut language);
        bool GetLanguage(int id, out Language language);
        bool DeleteLanguage(int id);
    }
}




