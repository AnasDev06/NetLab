using NetLab.Models;

namespace NetLab.Services
{
    public class NetworkStatistics
    {
        public void Display(NetworkGraph network)
        {
            int nodeCount = network.Connections.Count;

            int totalDirectedConnections =
                network.Connections.Values
                .Sum(list => list.Count);

            int connectionCount =
                totalDirectedConnections / 2;

            int maxConnections = 0;

            foreach (List<Connection> connections
                     in network.Connections.Values)
            {
                if (connections.Count > maxConnections)
                {
                    maxConnections = connections.Count;
                }
            }

            double averageDegree =
                nodeCount == 0
                    ? 0
                    : (double)totalDirectedConnections / nodeCount;

            Console.WriteLine("=== Network Statistics ===");
            Console.WriteLine($"Nodes: {nodeCount}");
            Console.WriteLine($"Connections: {connectionCount}");
            Console.WriteLine(
                $"Average Degree: {averageDegree:F2}");
            Console.WriteLine(
                $"Maximum Degree: {maxConnections}");
        }
    }
}