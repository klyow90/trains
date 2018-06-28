using NUnit.Framework;
using System.Collections.Generic;
using Trains.Entities;
using Trains.Services;
using Trains.Tests.Data;

namespace Trains.Tests.Services
{
    [TestFixture]
    public class TripServiceTest
    {
        [TestCase('C', 'C', 3, false, 2)]
        [TestCase('A', 'C', 4, true, 3)]
        public void GetRoutes_WithMaxOrExactMax(char from, char to, int max, bool isExactMax, int expected)
        {
            var service = new TripService(TestData.Edges);
            var routes = service.GetRoutes(from, to, max, isExactMax);
            Assert.AreEqual(expected, routes.Count);
        }

        [TestCase('A', 'C', 10, 9)]
        [TestCase('B', 'B', 10, 9)]
        public void GetShortestRouteDistance(char from, char to, int max, int expected)
        {
            var service = new TripService(TestData.Edges);
            var distance = service.GetShortestRouteDistance(from, to);
            Assert.AreEqual(expected, distance);
        }

        [TestCase('C', 'C', 30, 7)]
        public void GetRoutes_WithMaxDistanceThreshold(char from, char to, int maxDistance, int expected)
        {
            var service = new TripService(TestData.Edges);
            var routes = service.GetRoutes(from, to, maxDistance);
            Assert.AreEqual(expected, routes.Count);
        }
    }
}