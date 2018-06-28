using System.Collections.Generic;
using Trains.Entities;

namespace Trains.Tests.Data
{
    public class TestData
    {
        public static List<Edge> Edges = 
            new List<Edge>()
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
    }
}