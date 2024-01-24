﻿using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.EndPoints
{
    public static class StudentEndPoints
    {


        public static void ConfigureStudentEndpoints(this WebApplication app)
        {
            var taskGroup = app.MapGroup("students");
            taskGroup.MapPost("/", AddStudent);
            taskGroup.MapGet("/", GetAllStudents);
            taskGroup.MapGet("/{FirstName}", GetStudentsWithFirstName);
            taskGroup.MapDelete("/{FirstName}", DeleteStudentsWithFirstName);
            taskGroup.MapPut("/{FirstName}", UpdateStudentWithFirstName);


            //taskGroup.MapPut("/{id}", UpdateTask);
        }

        public static IResult AddStudent(Student student, IStudentRepository studentRepository
            )
        {

            studentRepository.Add(student);
            string url = "";
            return Results.Created(url, student);
        }

        public static IResult GetAllStudents(IStudentRepository studentRepository
            )
        {

            return Results.Ok(studentRepository.GetAll());
        }
        public static IResult GetStudentsWithFirstName(string FirstName, IStudentRepository studentRepository
            )
        {
            List<Student> filt = studentRepository.GetAll().Where(student => student.FirstName == FirstName).ToList();
            return Results.Ok(filt);
        }

        public static IResult DeleteStudentsWithFirstName(string FirstName, IStudentRepository studentRepository)
        {

            Student? student = studentRepository.GetAll().FirstOrDefault(student => student.FirstName == FirstName);

            bool result = studentRepository.Delete(student);

            if (result) { return Results.Ok(student); }
            return Results.BadRequest();
        }

        public static IResult UpdateStudentWithFirstName(string FirstName, Student updatedStudent, IStudentRepository studentRepository)
        {
            Student? studentToUpdate = studentRepository.GetAll().FirstOrDefault(s => s.FirstName == FirstName);

            if (studentToUpdate == null)
            {
                return Results.NotFound($"No student found with first name {FirstName}");
            }

            studentToUpdate.FirstName = updatedStudent.FirstName;
            studentToUpdate.LastName = updatedStudent.LastName;


            return Results.Ok(studentToUpdate);
        }




    }
}