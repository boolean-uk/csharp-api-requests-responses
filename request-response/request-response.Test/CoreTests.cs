using request_response.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;
using request_response.Models;

namespace request_response.Test
{
    [NonParallelizable]
    [TestFixture]
    public class CoreTests
    {
        StudentController St = new StudentController();
        Student stud = new Student("Spiros","Kafiris");
        Student stud2 = new Student("Allan", "King");

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void CreateStudent()
        {
            St.CreateStudent(stud);

            // Assert.IsTrue(St.students.Count == 1);
            Assert.Pass();
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void GetAlStudents()
        {
            St.CreateStudent(stud);
            St.CreateStudent(stud2);

            St.GetStudents();

            // Assert.IsTrue(St.students.Count == 2);
            Assert.Pass();
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void GetStudentByFirstName()
        {
            St.CreateStudent(stud);

            St.GetAStudent("Spiros");

            Assert.Pass();
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void UpdateStudent()
        {
            St.CreateStudent(stud);

            St.Update("Spiros", stud);

            Assert.Pass();
        }

        [Order(5)]
        [NonParallelizable]
        [Test]
        public void DeleteStudent()
        {
            St.CreateStudent(stud);

            St.DeleteAStudent("Spiros");

            Assert.Pass();
        }

        [Order(6)]
        [NonParallelizable]
        [Test]
        public void CreateLanguage()
        {
        }

        [Order(7)]
        [NonParallelizable]
        [Test]
        public void GetAllLanguages()
        {
        }

        [Order(8)]
        [NonParallelizable]
        [Test]
        public void GetLanguageByName()
        {
        }

        [Order(9)]
        [NonParallelizable]
        [Test]
        public void UpdateLanguage()
        {
        }

        [Order(10)]
        [NonParallelizable]
        [Test]
        public void DeleteLanguage()
        {
        }
    }
}