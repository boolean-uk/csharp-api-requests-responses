using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints.cs
{
    public static class StudentsEndpoint
    {
        //Extension method to configure the /students endpoint
        public static void ConfigureStudentsEndpoint(this WebApplication app)
        {
            // Create a group for endpoints related to students
            var studentGroup = app.MapGroup("students");

            // Map the GET request to /students
            studentGroup.MapGet("/", GetStudents);

            // Map the POST request to /students
            studentGroup.MapPost("/", AddStudents);

            // Map the GET request to /students/{firstName}
            studentGroup.MapGet("/{firstName}", GetStudent);

            // Map the PUT request to /students/{firstName}
            studentGroup.MapPut("/{firstName}", UpdateStudent);

            // Map the DELETE request to /students/{firstName}
            studentGroup.MapDelete("/{firstName}", DeleteStudent);
        }

        // Handler for the GET request to /students
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetStudents(IRepository repository)
        {
            // Return a 200 OK response with the list of students
            return TypedResults.Ok(repository.GetStudents());
        }

        //Handler for the POST request to /students
        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> AddStudents(IRepository repository, Student student)
        {
            // Add the student to the repository
            var addedStudent = repository.AddStudent(student);

            // Return a 201 Created response with the added student's details
            return TypedResults.Created($"/students/{addedStudent.FirstName}", addedStudent);
        }

        /*This endpoint method Gets a single student by their first name, if the student is found, a 200 OK, if not 404 Not found response will be returned*/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetStudent(IRepository repository, string firstName)
        {
            // Retrieve the student with the provided first name from the repository
            var student = repository.GetStudent(firstName);

            // Check if the student was found
            if (student == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Student with first name '{firstName}' not found.");
            }

            // If found, return a 200 OK response with the student details
            return TypedResults.Ok(student);
        }

        /*This endpoint method updates the details of a student by their first name.
         If the student is found and updated, a 201 Created response with the updated student details is returned.
         If the student is not found, a 404 Not Found response is returned.
         */
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateStudent(IRepository repository, string firstName, Student updatedStudent)
        {
            // Attempt to update the student details in the repository
            var result = repository.UpdateStudent(firstName, updatedStudent);

            // Check if the student was found and updated
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Student with first name '{firstName}' not found.");
            }

            // If found and updated, return a 201 Created response with the updated student details
            return TypedResults.Created($"/students/{result.FirstName}", result);
        }

        // This endpoint method handles the DELETE request for deleting a student by first name.
        // It attempts to delete the student from the repository using the provided first name.
        // If the student is found and deleted, a 200 OK response with the deleted student details is returned.
        // If the student is not found, a 404 Not Found response with a relevant error message is returned.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteStudent(IRepository repository, string firstName)
        {
            // Attempt to delete the student from the repository
            var result = repository.DeleteStudent(firstName);

            // Check if the student was not found
            if (result == null)
            {
                // If not found, return a 404 Not Found response with an error message
                return TypedResults.NotFound($"Student with first name '{firstName}' not found.");
            }

            // If found and deleted, return a 200 OK response with the deleted student details
            return TypedResults.Ok(result);
        }



    }
}

