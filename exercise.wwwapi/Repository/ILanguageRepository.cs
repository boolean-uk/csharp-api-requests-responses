﻿using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface ILanguageRepository
    {
        Language AddLanguage(string name);

        List<Language> GetLanguages();

        Language GetLanguage(string name);

        Language UpdateLanguage(string name, string newName);

        Language DeleteLanguage(string name);
    }
}
