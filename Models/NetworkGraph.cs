using System.Collections.Generic;

namespace NetLab.Models
{
    public class NetworkGraph
    {
        public Dictionary<NetworkNode, List<Connection>> Connections { get; set; }

        public NetworkGraph()
        {
            Connections = new Dictionary<NetworkNode, List<Connection>>();
        }
    }
}