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

            Console.WriteLine("Input");
            Console.WriteLine("1. The distance of the route A-B-C");
            Console.WriteLine("2. The distance of the route A-D.");
            Console.WriteLine("3. The distance of the route A-D-C.");
            Console.WriteLine("4. The distance of the route A-E-B-C-D.");
            Console.WriteLine("5. The distance of the route A-E-D.");
            Console.WriteLine("6. The number of trips starting at C and ending at C with a maximum of 3 stops.");
            Console.WriteLine("7. The number of trips starting at A and ending at C with exactly 4 stops.");
            Console.WriteLine("8. The length of the shortest route (in terms of distance to travel) from A to C.");
            Console.WriteLine("9. The length of the shortest route (in terms of distance to travel) from B to B.");
            Console.WriteLine("10. The number of different routes from C to C with a distance of less than 30.");
            Console.WriteLine("\n");
            Console.WriteLine("Output");
            PrintDistance(edges, 1, "A-B-C");
            PrintDistance(edges, 2, "A-D");
            PrintDistance(edges, 3, "A-D-C");
            PrintDistance(edges, 4, "A-E-B-C-D");
            PrintDistance(edges, 5, "A-E-D");
            PrintMaxStops(edges, 6, 'C', 'C', 3);
            PrintExactMaxStops(edges, 7, 'A', 'C', 4);
            PrintShortestDistance(edges, 8, 'A', 'C');
            PrintShortestDistance(edges, 9, 'B', 'B');
            PrintDifferentRoutes(edges, 10, 'C', 'C', 30);
        }

        private static void PrintDistance(List<Edge> edges, int number, string route)
        {
            var service = new RouteService(edges);
            try
            {
                Print(number, service.GetDistance(route).ToString());
            }
            catch (Exception e)
            {
                Print(number, e.Message);
            }
        }

        private static void PrintMaxStops(List<Edge> edges, int number, char from, char to, int maxDepth)
        {
            var service = new TripService(edges);
            var routes = service.GetRoutes(from, to, maxDepth, false);
            Print(number, routes.Count.ToString());
        }

        private static void PrintExactMaxStops(List<Edge> edges, int number, char from, char to, int maxDepth)
        {
            var service = new TripService(edges);
            var routes = service.GetRoutes(from, to, maxDepth, true);
            Print(number, routes.Count.ToString());
        }

        private static void PrintShortestDistance(List<Edge> edges, int number, char from, char to)
        {
            var service = new TripService(edges);
            var distance = service.GetShortestRouteDistance(from, to);
            Print(number, distance.ToString());
        }

        private static void PrintDifferentRoutes(List<Edge> edges, int number, char from, char to, int maxDistance)
        {
            var service = new TripService(edges);
            var routes = service.GetRoutes(from, to, maxDistance);
            Print(number, routes.Count.ToString());
        }

        private static void Print(int number, string output)
        {
            Console.WriteLine(string.Format("Output #{0}: {1}", number, output));
        }
    }
}