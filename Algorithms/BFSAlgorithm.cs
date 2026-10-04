using NetLab.Models;

namespace NetLab.Algorithms
{
    public class BFSAlgorithm
    {
        public List<NetworkNode> FindPath(
            NetworkGraph network,
            NetworkNode start,
            NetworkNode target)
        {
            Queue<NetworkNode> queue = new Queue<NetworkNode>();
            HashSet<NetworkNode> visited = new HashSet<NetworkNode>();
            Dictionary<NetworkNode, NetworkNode?> previous =
                new Dictionary<NetworkNode, NetworkNode?>();

            queue.Enqueue(start);
            visited.Add(start);
            previous[start] = null;

            while (queue.Count > 0)
            {
                NetworkNode current = queue.Dequeue();

                if (current == target)
                {
                    break;
                }

                if (!network.Connections.ContainsKey(current))
                {
                    continue;
                }

                foreach (Connection connection in network.Connections[current])
                {
                    NetworkNode neighbor = connection.To;

                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        previous[neighbor] = current;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (!visited.Contains(target))
            {
                return new List<NetworkNode>();
            }

            List<NetworkNode> path = new List<NetworkNode>();
            NetworkNode? node = target;

            while (node != null)
            {
                path.Add(node);
                node = previous[node];
            }

            path.Reverse();

            return path;
        }
    }
}