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
    [TestFixture]
    public class ExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void CreateBook()
        {
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void GetAlBooks()
        {
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void GetBookByFirstName()
        {
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void UpdateBook()
        {
        }

        [Order(5)]
        [NonParallelizable]
        [Test]
        public void DeleteBook()
        {
        }
    }
}