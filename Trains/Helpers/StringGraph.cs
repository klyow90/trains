using System;
using System.Collections.Generic;
using Trains.Entities;

namespace Trains.Helpers
{
    public class StringGraph
    {
        public static List<Edge> ToEdgeList(string graph)
        {
            var edges = graph.Split(",");
            var tmp = new List<Edge>();

            foreach(var e in edges)
            {
                var edge = e.Trim();
                var from = edge[0];
                var to = edge[1];
                var cost = edge[2] - '0';

                tmp.Add(new Edge(from, to, cost));
            }

            return tmp;
        }
    }
}