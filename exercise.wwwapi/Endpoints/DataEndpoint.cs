using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class DataEndpoint
    {
        public static void ConfigureDataEndpoint(this WebApplication app)
        {
            var dataGroup = app.MapGroup("data");

            dataGroup.MapGet("/students", GetStudents);
            dataGroup.MapGet("/student/{firstName}", GetStudent);
            dataGroup.MapPost("/student/add/{firstName}, {lastName}", AddStudent);
            dataGroup.MapPut("/student/update/{firstName}, {newFirstName}", UpdateStudent);
            dataGroup.MapDelete("/student/delete/{firstName}", DeleteStudent);



            dataGroup.MapGet("/languages", GetLanguageData);


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            return TypedResults.Ok(repository.getStudentCollections());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetLanguageData(IRepository repository)
        {
            return TypedResults.Ok(repository.getLanguageCollections());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.getStudent(firstName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddStudent(IRepository repository, string firstName, string lastName)
        {
            return TypedResults.Ok(repository.addStudent(firstName, lastName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, string newFirstName, string newLastName)
        {
            return TypedResults.Ok(repository.updateStudent(firstName, newFirstName, newLastName));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            return TypedResults.Ok(repository.deleteStudent(firstName));
        }
    }
}
