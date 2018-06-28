using System;
using System.Collections.Generic;
using System.IO;
using Trains.Constants;
using Trains.Entities;
using Trains.Helpers;
using Trains.Services;

namespace Trains
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(GraphData.Directory, GraphData.FileName);
            var reader = new FileReader(path);
            var data = reader.ReadAllText();

            var edgeService = new EdgeService(data);
            var edges = edgeService.GetEdges();

            var routeDistanceService = new RouteDistanceService(edges);
            //Console.WriteLine(routeDistanceService.GetRouteCost("A-E-B-C-D"));
            var service = new PossibleRouteService(edges);
            var routes = service.GetRoutes('B', 'B', 5, false);
            var shortest = service.ShortestRouteCost(routes);

            foreach (var item in routes)
            {
                Console.WriteLine(item.First);
            }

        }
    }
}
