using NUnit.Framework;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using request_response.Controllers;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace request_response.Test
{
    [NonParallelizable]
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void AddStudent()
        {
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void GetAlStudents()
        {
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void GetStudentByName()
        {
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void UpdateStudent()
        {
        }

        [Order(5)]
        [NonParallelizable]
        [Test]
        public void DeleteStudent()
        {
        }

        [Order(6)]
        [NonParallelizable]
        [Test]
        public void AddLanguage()
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