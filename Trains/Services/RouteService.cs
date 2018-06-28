using System;
using System.Collections.Generic;
using System.Linq;
using Trains.Entities;

namespace Trains.Services
{
    public class RouteService
    {
        private readonly List<Edge> _Edges;

        public RouteService(List<Edge> edges)
        {
            _Edges = edges;
        }

        public int GetDistance(string route)
        {
            var routeArray = route.Split("-");
            var cost = 0;

            for (int i = 1; i < routeArray.Length; i++)
            {
                var from = routeArray[i-1];
                var to = routeArray[i];

                var edge = _Edges.Where(x => x.From == Convert.ToChar(from) && x.To == Convert.ToChar(to)).FirstOrDefault();

                if(edge == null)
                {
                    throw new Exception("NO SUCH ROUTE");
                }

                cost += edge.Cost;
            }

            return cost;
        }
    }
}