using NetLab.Models;

namespace NetLab.Services
{
    public class NetworkService
    {
        private readonly NetworkGraph _network;

        public NetworkService(NetworkGraph network)
        {
            _network = network;
        }

        public void AddNode(NetworkNode node)
        {
            if (!_network.Connections.ContainsKey(node))
            {
                _network.Connections[node] = new List<Connection>();
            }
        }

        public void AddConnection(
            NetworkNode from,
            NetworkNode to,
            int cost)
        {
            AddNode(from);
            AddNode(to);

            Connection connection =
                new Connection(from, to, cost);

            Connection reverseConnection =
                new Connection(to, from, cost);

            _network.Connections[from].Add(connection);
            _network.Connections[to].Add(reverseConnection);
        }

        public bool RemoveConnection(
            NetworkNode from,
            NetworkNode to)
        {
            if (!_network.Connections.ContainsKey(from) ||
                !_network.Connections.ContainsKey(to))
            {
                return false;
            }

            Connection? connection =
                _network.Connections[from]
                .FirstOrDefault(c => c.To == to);

            Connection? reverseConnection =
                _network.Connections[to]
                .FirstOrDefault(c => c.To == from);

            if (connection == null)
            {
                return false;
            }

            _network.Connections[from].Remove(connection);

            if (reverseConnection != null)
            {
                _network.Connections[to].Remove(reverseConnection);
            }

            return true;
        }

        public bool RemoveNode(NetworkNode node)
        {
            if (!_network.Connections.ContainsKey(node))
            {
                return false;
            }

            foreach (NetworkNode otherNode in
                     _network.Connections.Keys.ToList())
            {
                if (otherNode != node)
                {
                    _network.Connections[otherNode]
                        .RemoveAll(c => c.To == node);
                }
            }

            _network.Connections.Remove(node);

            return true;
        }

        public void DisplayNetwork()
        {
            Console.WriteLine("=== Network Topology ===");

            foreach (var entry in _network.Connections)
            {
                NetworkNode node = entry.Key;

                Console.Write($"{node.Name}: ");

                if (entry.Value.Count == 0)
                {
                    Console.Write("No connections");
                }

                foreach (Connection connection in entry.Value)
                {
                    Console.Write(
                        $"{connection.To.Name}({connection.Cost}) ");
                }

                Console.WriteLine();
            }
        }
    }
}