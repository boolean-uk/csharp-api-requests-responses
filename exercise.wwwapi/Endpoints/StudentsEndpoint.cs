using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi
{
    public static class StudentsEndpoint
    {
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            var students = app.MapGroup("students");

            students.MapGet("/", GetAll);
            students.MapPost("/", Add);
            students.MapDelete("/{firstName}", Delete);
            students.MapPut("/{firstName}", Update);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAll(StudentsRepository studentsRepository)
        {
            var students = studentsRepository.GetAll();
            return Results.Ok(students);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> Add(StudentsRepository studentsRepository, string firstName, string lastName)
        {
            Student student = new Student() { FirstName = firstName, LastName = lastName};
            studentsRepository.Add(student);

            return Results.Created($"https://localhost:7010/students/{student.FirstName}", student);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Delete(StudentsRepository studentsRepository, string firstName)
        {
            var student = studentsRepository.Get(firstName);
            if (student != null && studentsRepository.Delete(firstName))
            {
                return Results.Ok(new { Status = "Deleted", Student = student });
            }
            return Results.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> Update(StudentsRepository studentsRepository, string firstName, string newFirstName, string newLastName)
        {
            var student = studentsRepository.Get(firstName);
            if (student == null) return Results.NotFound();

            var updatedStudent = studentsRepository.Update(firstName, newFirstName, newLastName);
            if (updatedStudent != null)
            {
                return Results.Ok(updatedStudent);
            }

            return Results.BadRequest();
        }

    }
}
