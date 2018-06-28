using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Entities;

namespace Trains.Services
{
    public class TripService
    {
        private readonly Dictionary<char, List<Edge>> _Adjacents = new Dictionary<char, List<Edge>>();

        public TripService(List<Edge> edges)
        {
            InitAdjacents(edges);    
        }

        public List<LinkedList<Edge>> GetRoutes(char from, char to, int maxDepth, bool isExactMax)
        {
            return GetRoutes(from, to, 0, maxDepth, isExactMax, -1, new List<LinkedList<Edge>>(), new LinkedList<Edge>());
        }

        public List<LinkedList<Edge>> GetRoutes(char from, char to, int maxDistance)
        {
            return GetRoutes(from, to, 0, maxDistance, false, maxDistance, new List<LinkedList<Edge>>(), new LinkedList<Edge>());
        }

        public int GetShortestRouteDistance(char from, char to)
        {
            var routes = GetRoutes(from, to, 0, 10, false, -1, new List<LinkedList<Edge>>(), new LinkedList<Edge>());

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
                var tmpRoute = new LinkedList<Edge>();

                foreach (var edge in route)
                {
                    tmpRoute.AddLast(edge);
                }
                routes.Add(tmpRoute);

                //return routes;
            }

            if(depthIndex >= maxDepth)
            {
                return routes;
            }

            var currentDistance = route.Sum(x => x.Cost);

            if(ApplyMaxDistanceRule(maxDistance) 
                && HitMaxDistanceThreshold(currentDistance, maxDistance))
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

        private bool ApplyMaxDistanceRule(int maxDistance)
        {
            return maxDistance > 0;
        }

        private bool HitMaxDistanceThreshold(int currentDistance, int maxDistance)
        {
            return currentDistance >= maxDistance;
        }
    }
}