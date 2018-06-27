namespace Trains.Entities
{
    public class Edge
    {
        public char From { get; }
        public char To { get; }
        public int Cost { get; }

        public Edge(char from, char to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
}