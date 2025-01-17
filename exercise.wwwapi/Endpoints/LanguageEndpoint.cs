using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class LanguageEndpoint
    {
        public static void ConfigureLanguageEndpoint(this WebApplication app)
        {
            var pets = app.MapGroup("language");

            pets.MapGet("/gettAll", GetAllLanguages);
            pets.MapGet("/get{FirstName}", GetLanguage);
            pets.MapPost("/add", AddLanguage);
            pets.MapDelete("/delete{Firstname}", DeleteLanguage);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguage(IRepository repository, string FirstName)
        {
            var student = repository.GetLanguages().FirstOrDefault(x => x.Name == FirstName);
            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllLanguages(IRepository repository)
        {
            var students = repository.GetStudents();
            return Results.Ok(students);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddLanguage(IRepository repository, Language model)
        {
            Language student = new Language(model.Name);
            //{
            //    Name = model.Name,
            //};
            repository.AddLanguage(student);

            return Results.Ok(student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> DeleteLanguage(IRepository repository, string FirstName)
        {
            try
            {
                var model = repository.GetLanguage(FirstName);
                if (repository.DeleteL(FirstName)) return Results.Ok(new { When = DateTime.Now, Status = "Deleted", Name = model.Name});
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
