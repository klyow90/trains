using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Entities;

namespace Trains.Services
{
    public class PossibleRouteService
    {
        private readonly Dictionary<char, List<Edge>> _Adjacents = new Dictionary<char, List<Edge>>();

        public PossibleRouteService(List<Edge> edges)
        {
            InitAdjacents(edges);    
        }

        public List<LinkedList<Edge>> GetRoutes(char from, char to, int max, bool isExactMax)
        {
            return GetRoutes(from, to, 0, max, isExactMax, -1, new List<LinkedList<Edge>>(), new LinkedList<Edge>());
        }

        public int ShortestRouteCost(List<LinkedList<Edge>> routes)
        {
            var shortest = int.MaxValue;
            
            foreach (var route in routes)
            {
                var totalCost = route.Sum(x => x.Cost);

                if(totalCost < shortest)
                {
                    shortest = totalCost;
                }
            }

            return shortest;
        }

        private List<LinkedList<Edge>> GetRoutes(char from, char to, int depthIndex, int maxDepth, bool isExactMax, int maxDistance,
            List<LinkedList<Edge>> routes, LinkedList<Edge> route)
        {
            var adjacents = _Adjacents[from];

            if((from == to && depthIndex != 0) && ((isExactMax && depthIndex == maxDepth) || !isExactMax))
            {
                var r = new LinkedList<Edge>();

                foreach (var edge in route)
                {
                    r.AddLast(edge);
                }
                routes.Add(r);
                return routes;
            }

            if(depthIndex >= maxDepth)
            {
                return routes;
            }

            depthIndex++;

            foreach (var adj in adjacents)
            {
                route.AddLast(adj);
                routes = GetRoutes(adj.To, to, depthIndex, maxDepth, isExactMax, maxDistance, routes, route);
                route.RemoveLast();
            }
            return routes;
        }

        private void InitAdjacents(List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if(!_Adjacents.ContainsKey(edge.From))
                {
                    _Adjacents[edge.From] = new List<Edge>();
                }
                
                _Adjacents[edge.From].Add(edge);
            }
        }
    }
}