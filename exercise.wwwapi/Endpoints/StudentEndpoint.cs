using exercise.wwwapi.Interfaces;
using exercise.wwwapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints;

public static class StudentEndpoint
{
    public static void ConfigureStudentEndpoint(this WebApplication app)
    {
        var stud = app.MapGroup("stud");
        stud.MapGet("/", GetAllStudents);
        stud.MapPost("/", CreateNewStudent);
        stud.MapGet("/{firstName}", GetStudent);
        stud.MapPut("/{firstName}", UpdateStudent);
        stud.MapDelete("/{firstName}", DeleteStudent);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static IResult GetAllStudents(IRepository<Student, string> collection)
    {
        return TypedResults.Ok(collection.GetAll());
    }
    
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult GetStudent(IRepository<Student, string> collection, string firstName)
    {
        var s = collection.GetAll().FirstOrDefault(x => x.FirstName.ToLower().Equals(firstName.ToLower()));
        if (s is null) return TypedResults.NotFound();
        return TypedResults.Ok(s);
    }
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    public static IResult CreateNewStudent(IRepository<Student, string> collection, Student student)
    {
        var s = collection.Create(student);
        return TypedResults.Created($"/stud{s.FirstName}", s);
    }
    
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult UpdateStudent(IRepository<Student, string> collection, string firstName, Student student)
    {
        var s = collection.GetAll().FirstOrDefault(x => x.FirstName == firstName);
        if (s is null) return TypedResults.NotFound();
        s.FirstName = student.FirstName;
        s.LastName = student.FirstName;
        return TypedResults.Created($"/stud{s.FirstName}", s);
    }
    
    
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static IResult DeleteStudent(IRepository<Student, string> collection, string firstName)
    {
        var s = collection.GetAll().FirstOrDefault(x => x.FirstName.ToLower().Equals(firstName.ToLower()));
        if (s is null) return TypedResults.NotFound();
        
        return TypedResults.Ok(collection.Delete(s));
    }
}