using NUnit.Framework;
using System;
using System.Collections.Generic;
using Trains.Entities;
using Trains.Services;
using Trains.Tests.Data;

namespace Trains.Tests.Services
{
    [TestFixture]
    public class RouteServiceTest
    {
        [TestCase("A-B-C", 9)]
        [TestCase("A-D", 5)]
        [TestCase("A-D-C", 13)]
        [TestCase("A-E-B-C-D", 22)]
        public void GetRouteCost(string route, int expected)
        {
            var service = new RouteService(TestData.Edges);
            Assert.AreEqual(expected, service.GetDistance(route));
        }

        [TestCase("A-E-D", "NO SUCH ROUTE")]
        public void GetRouteCost_ShouldThrowExceptionWithMessage(string route, string expected)
        {
            var service = new RouteService(TestData.Edges);
            var exception = Assert.Throws<Exception>(() => service.GetDistance(route));
            Assert.AreEqual(expected, exception.Message);
        }
    }
}