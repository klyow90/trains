using NUnit.Framework;
using System.Collections.Generic;
using Trains.Entities;
using Trains.Services;

namespace Trains.Tests.Services
{
    [TestFixture]
    public class PossibleRouteServiceTest
    {
        [TestCase('C', 'C', 3, false, 2)]
        [TestCase('A', 'C', 4, true, 3)]
        public void GetRoutes(char from, char to, int max, bool isExactMax, int expected)
        {
            var edges = new List<Edge>()
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

            var service = new PossibleRouteService(edges);
            var routes = service.GetRoutes(from, to, max, isExactMax);
            Assert.AreEqual(expected, routes.Count);
        }

        [TestCase('A', 'C', 10, 9)]
        [TestCase('B', 'B', 10, 9)]
        public void ShortestRouteCost(char from, char to, int max, int expected)
        {
            var edges = new List<Edge>()
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

            var service = new PossibleRouteService(edges);
            var routes = service.GetRoutes(from, to, max, false);
            var cost = service.ShortestRouteCost(routes);
            Assert.AreEqual(expected, cost);
        }

        [TestCase('A', 'C', 10, 9)]
        [TestCase('B', 'B', 10, 9)]
        public void ShortestRouteCost(char from, char to, int max, int expected)
        {
            var edges = new List<Edge>()
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

            var service = new PossibleRouteService(edges);
            var routes = service.GetRoutes(from, to, max, false);
        }
    }
}