using NetLab.Algorithms;
using NetLab.Models;
using NetLab.Services;

namespace NetLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetworkGraph network = new NetworkGraph();
            NetworkService service = new NetworkService(network);

            NetworkNode A = new NetworkNode("A");
            NetworkNode B = new NetworkNode("B");
            NetworkNode C = new NetworkNode("C");
            NetworkNode D = new NetworkNode("D");

            service.AddConnection(A, B, 4);
            service.AddConnection(A, C, 2);
            service.AddConnection(C, B, 1);
            service.AddConnection(B, D, 5);
            service.AddConnection(C, D, 8);

            Console.WriteLine("================================");
            Console.WriteLine("          NETLAB SIMULATOR      ");
            Console.WriteLine("================================");
            Console.WriteLine();

            service.DisplayNetwork();

            Console.WriteLine();

            BFSAlgorithm bfs = new BFSAlgorithm();
            DFSAlgorithm dfs = new DFSAlgorithm();
            DijkstraAlgorithm dijkstra =
                new DijkstraAlgorithm();

            List<NetworkNode> bfsPath =
                bfs.FindPath(network, A, D);

            List<NetworkNode> dfsPath =
                dfs.FindPath(network, A, D);

            List<NetworkNode> shortestPath =
                dijkstra.FindShortestPath(
                    network, A, D);

            int shortestCost =
                dijkstra.CalculatePathCost(
                    network, shortestPath);

            Console.WriteLine("=== Routing Algorithms ===");

            Console.WriteLine(
                $"BFS: {string.Join(" -> ", bfsPath)}");

            Console.WriteLine(
                $"DFS: {string.Join(" -> ", dfsPath)}");

            Console.WriteLine(
                $"Dijkstra: {string.Join(" -> ", shortestPath)}");

            Console.WriteLine(
                $"Shortest Cost: {shortestCost}");

            Console.WriteLine();

            Packet packet = new Packet(
                "P001",
                A,
                D,
                "Hello from A to D");

            PacketService packetService =
                new PacketService();

            packetService.SendPacket(
                packet,
                shortestPath);

            Console.WriteLine();

            NetworkStatistics statistics =
                new NetworkStatistics();

            statistics.Display(network);

            Console.WriteLine();
            Console.WriteLine(
                "Press any key to exit...");

            Console.ReadKey();
        }
    }
}