using NetLab.Models;

namespace NetLab.Algorithms
{
    public class DijkstraAlgorithm
    {
        public List<NetworkNode> FindShortestPath(
            NetworkGraph network,
            NetworkNode start,
            NetworkNode target)
        {
            Dictionary<NetworkNode, int> distances =
                new Dictionary<NetworkNode, int>();

            Dictionary<NetworkNode, NetworkNode?> previous =
                new Dictionary<NetworkNode, NetworkNode?>();

            HashSet<NetworkNode> unvisited =
                new HashSet<NetworkNode>();

            foreach (NetworkNode networkNode in network.Connections.Keys)
            {
                distances[networkNode] = int.MaxValue;
                previous[networkNode] = null;
                unvisited.Add(networkNode);
            }

            if (!distances.ContainsKey(start) ||
                !distances.ContainsKey(target))
            {
                return new List<NetworkNode>();
            }

            distances[start] = 0;

            while (unvisited.Count > 0)
            {
                NetworkNode? current =
                    GetClosestNode(unvisited, distances);

                if (current == null)
                {
                    break;
                }

                unvisited.Remove(current);

                if (current == target)
                {
                    break;
                }

                foreach (Connection connection in network.Connections[current])
                {
                    NetworkNode neighbor = connection.To;

                    if (!unvisited.Contains(neighbor))
                    {
                        continue;
                    }

                    if (distances[current] == int.MaxValue)
                    {
                        continue;
                    }

                    int newDistance =
                        distances[current] + connection.Cost;

                    if (newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        previous[neighbor] = current;
                    }
                }
            }

            if (distances[target] == int.MaxValue)
            {
                return new List<NetworkNode>();
            }

            List<NetworkNode> path = new List<NetworkNode>();

            NetworkNode? pathNode = target;

            while (pathNode != null)
            {
                path.Add(pathNode);
                pathNode = previous[pathNode];
            }

            path.Reverse();

            return path;
        }

        private NetworkNode? GetClosestNode(
            HashSet<NetworkNode> unvisited,
            Dictionary<NetworkNode, int> distances)
        {
            NetworkNode? closestNode = null;
            int shortestDistance = int.MaxValue;

            foreach (NetworkNode networkNode in unvisited)
            {
                if (distances[networkNode] < shortestDistance)
                {
                    shortestDistance = distances[networkNode];
                    closestNode = networkNode;
                }
            }

            return closestNode;
        }

        public int CalculatePathCost(
            NetworkGraph network,
            List<NetworkNode> path)
        {
            int totalCost = 0;

            for (int i = 0; i < path.Count - 1; i++)
            {
                NetworkNode currentNode = path[i];
                NetworkNode nextNode = path[i + 1];

                Connection? connection =
                    network.Connections[currentNode]
                    .FirstOrDefault(c => c.To == nextNode);

                if (connection != null)
                {
                    totalCost += connection.Cost;
                }
            }

            return totalCost;
        }
    }
}