using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.ComponentModel.DataAnnotations;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private static List<Language> languages = new List<Language>();
        public LanguageController()
        {
            if(languages.Count == 0)
            {
                Language language = new Language();
                language.Name = "Java";
                languages.Add(language);
            }

        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {

                return Results.Ok(languages);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpGet]
        [Route("{name}")]

        public async Task<IResult> GetLangauge(string name)
        {
            try
            {
              var result = languages.Where(x=>x.Name.ToLower() == name.ToLower()).FirstOrDefault();

               
                
                return Results.NotFound(result);


            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        [HttpDelete]
        public async Task<IResult> DeleteLangauge([Required] string name)
        {
            try
            {
                if (languages.Any(x => x.Name.ToLower() == name.ToLower()))
                {
                    var lang = languages.Where(x => x.Name.ToLower().Equals(name.ToLower())).FirstOrDefault();

                    languages.Remove(lang);
                    return Results.Ok(languages);
                }
                else
                {
                    return Results.NotFound(name);
                }


            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IResult> CreateLanguage(Language lang)
        {
            try
            {
                
                languages.Add(lang);
                return Results.Ok(languages);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPut]
        [Route("{name}")]

        public async Task<IResult> UpdateStudent([Required] string name, Language lang)
        {
            try
            {

               
                    foreach (var langauge in languages)
                    {
                        if (name.ToLower().Equals(langauge.Name.ToLower()))
                        {
                            langauge.Name = lang.Name;
                            return Results.Ok(lang);
                        }
                        
                    }
                    return Results.NotFound(lang);

                   

                    
                    

                    

                
               

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
    }
}