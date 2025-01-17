using System;
using AutoMapper;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace exercise.wwwapi.EndPoints;

public static class StudentEndpoint
{

    public static void ConfigureStudentEndpoint(this WebApplication app)
    {
        var student = app.MapGroup("student");

        student.MapGet("/{firstName}", GetStudent);
        student.MapGet("/", GetAllStudents);
        student.MapPost("/", CreateStudent);
        student.MapPatch("/{firstName}", UpdateStudent);
        student.MapDelete("/{firstName}", DeleteStudent);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> GetStudent(IStudentRepository repo, string firstName)
    {
        try
        {
            Student result = repo.Get(firstName);
            if (result == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(result);
        }
        catch (Exception e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    public static async Task<IResult> GetAllStudents(IStudentRepository repo)
    {
        return TypedResults.Ok(repo.GetAll());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public static async Task<IResult> CreateStudent(IStudentRepository repo,  Student entity)
    {
        try
        {
        Student result = repo.Create(entity);

        if (result == null)
        {
            return TypedResults.Conflict($"Student already in the system {entity.FirstName}");
        }

        return TypedResults.Ok(result);
        }
        catch (Exception e)
        {
            return TypedResults.BadRequest(e.Message);
        }
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> UpdateStudent(IStudentRepository repo, string firstName, Student entity)
    {
        Student result = repo.Update(firstName, entity);
        if (result == null)
        {
            return TypedResults.NotFound(firstName);
        }
        return TypedResults.Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public static async Task<IResult> DeleteStudent(IStudentRepository repo, string firstName)
    {
        if (repo.Delete(firstName))
        {
            return TypedResults.Ok(firstName);
        }
        return TypedResults.NotFound(firstName);
    }


    





}
