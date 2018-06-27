using NUnit.Framework;
using System;
using System.Collections.Generic;
using Trains.Entities;
using Trains.Services;

namespace Trains.Tests.Services
{
    [TestFixture]
    public class RouteDistanceServiceTest
    {
        [TestCase("A-B-C", 9)]
        [TestCase("A-D", 5)]
        [TestCase("A-D-C", 13)]
        [TestCase("A-E-B-C-D", 22)]
        public void GetRouteCost(string route, int expected)
        {
            var data = new List<Edge>()
            {
                new Edge('A', 'B', 5),
                new Edge('B', 'C', 4),
                new Edge('C', 'D', 8),
                new Edge('D', 'C', 8),
                new Edge('D', 'E', 6),
                new Edge('A', 'D', 5),
                new Edge('C', 'E', 2),
                new Edge('E', 'B', 3),
                new Edge('A', 'E', 7),
            };
            var service = new RouteDistanceService(data);
            Assert.AreEqual(expected, service.GetRouteCost(route));
        }

        [TestCase("A-E-D")]
        public void GetRouteCost_ShouldThrowExceptionWithMessage(string route)
        {
            var data = new List<Edge>()
            {
                new Edge('A', 'B', 5),
                new Edge('B', 'C', 4),
                new Edge('C', 'D', 8),
                new Edge('D', 'C', 8),
                new Edge('D', 'E', 6),
                new Edge('A', 'D', 5),
                new Edge('C', 'E', 2),
                new Edge('E', 'B', 3),
                new Edge('A', 'E', 7),
            };
            var service = new RouteDistanceService(data);
            var ex = Assert.Throws<Exception>(() => service.GetRouteCost(route));
            Assert.AreEqual("NO SUCH ROUTE", ex.Message);
        }
    }
}