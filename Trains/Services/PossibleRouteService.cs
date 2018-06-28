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
            return GetRoutes(from, to, 0, max, isExactMax, new List<LinkedList<Edge>>(), new LinkedList<Edge>());
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

        private List<LinkedList<Edge>> GetRoutes(char from, char to, int index, int max, bool isExactMax, List<LinkedList<Edge>> routes, LinkedList<Edge> route)
        {
            var adjacents = _Adjacents[from];

            if((from == to && index != 0) && ((isExactMax && index == max) || !isExactMax))
            {
                var r = new LinkedList<Edge>();

                foreach (var edge in route)
                {
                    r.AddLast(edge);
                }
                routes.Add(r);
                return routes;
            }

            if(index >= max)
            {
                return routes;
            }

            index++;

            foreach (var adj in adjacents)
            {
                route.AddLast(adj);
                routes = GetRoutes(adj.To, to, index, max, isExactMax, routes, route);
                route.RemoveLast();
                //route = new LinkedList<Edge>();
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