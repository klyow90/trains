using NUnit.Framework;
using System.Collections.Generic;
using Trains.Entities;
using Trains.Services;

namespace Trains.Tests.Services
{
    [TestFixture]
    public class EdgeServiceTest
    {
        private readonly string _Graph = "AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7";

        [Test]
        public void GetEdges()
        {
            var service = new EdgeService(_Graph);
            var edges = service.GetEdges();
            var expected = new List<Edge>()
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

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].From, edges[i].From);
                Assert.AreEqual(expected[i].To, edges[i].To);
                Assert.AreEqual(expected[i].Cost, edges[i].Cost);
            }
        }
    }
}