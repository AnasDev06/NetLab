using NetLab.Models;

namespace NetLab.Algorithms
{
    public class DFSAlgorithm
    {
        public List<NetworkNode> FindPath(
            NetworkGraph network,
            NetworkNode start,
            NetworkNode target)
        {
            HashSet<NetworkNode> visited = new HashSet<NetworkNode>();
            Dictionary<NetworkNode, NetworkNode?> previous =
                new Dictionary<NetworkNode, NetworkNode?>();

            bool found = Search(
                network,
                start,
                target,
                visited,
                previous);

            if (!found)
            {
                return new List<NetworkNode>();
            }

            List<NetworkNode> path = new List<NetworkNode>();
            NetworkNode? current = target;

            while (current != null)
            {
                path.Add(current);

                if (!previous.ContainsKey(current))
                {
                    break;
                }

                current = previous[current];
            }

            path.Reverse();

            return path;
        }

        private bool Search(
            NetworkGraph network,
            NetworkNode current,
            NetworkNode target,
            HashSet<NetworkNode> visited,
            Dictionary<NetworkNode, NetworkNode?> previous)
        {
            visited.Add(current);

            if (current == target)
            {
                return true;
            }

            if (!network.Connections.ContainsKey(current))
            {
                return false;
            }

            foreach (Connection connection in network.Connections[current])
            {
                NetworkNode neighbor = connection.To;

                if (!visited.Contains(neighbor))
                {
                    previous[neighbor] = current;

                    if (Search(
                        network,
                        neighbor,
                        target,
                        visited,
                        previous))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}