namespace NetLab.Models
{
    public class Connection
    {
        public NetworkNode From { get; set; }
        public NetworkNode To { get; set; }

        public int Cost { get; set; }

        public Connection(NetworkNode from, NetworkNode to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
}