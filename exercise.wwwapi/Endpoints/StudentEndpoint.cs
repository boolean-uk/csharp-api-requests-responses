using System;
using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.View;

namespace exercise.wwwapi.Endpoints;

public static class StudentEndpoint
{
    public static void ConfigureStudentEndpoint(this WebApplication app)
    {
        var students = app.MapGroup("students");

        students.MapGet("/", GetStudents);
        students.MapPost("/", AddStudent);
        students.MapGet("/{firstname}", GetStudent);
        students.MapDelete("/{firstname}", DeleteStudent);
        students.MapPut("/{firstname}", UpdateStudent);
    }

    public static async Task<IResult> GetStudents(IStudentRepository repository)
    {
        var students = repository.GetStudents();
        return Results.Ok(students);
    }

    public static async Task<IResult> GetStudent(IStudentRepository repository, string firstname)
    {
        var student = repository.GetStudent(firstname);
        if (student == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(student);
    }

    public static async Task<IResult> AddStudent(IStudentRepository repository, StudentPost student)
    {

        var newStudent = repository.AddStudent(new Student() { FirstName = student.FirstName, LastName = student.LastName});
        return Results.Created($"/students/{newStudent.FirstName}", newStudent);
    }

    public static async Task<IResult> UpdateStudent(IStudentRepository repository, string firstname, StudentPut student)
    {
        var updatedStudent = repository.UpdateStudent(firstname, new Student() { FirstName = student.FirstName, LastName = student.LastName });
        if (updatedStudent == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(updatedStudent);
    }

    public static async Task<IResult> DeleteStudent(IStudentRepository repository, string firstname)
    {
        var result = repository.DeleteStudent(firstname);
        if (!result)
        {
            return Results.NotFound();
        }
        return Results.NoContent();
    }
}
