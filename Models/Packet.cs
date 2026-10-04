namespace NetLab.Models
{
    public class Packet
    {
        public string Id { get; set; }
        public NetworkNode Source { get; set; }
        public NetworkNode Destination { get; set; }
        public string Data { get; set; }

        public Packet(
            string id,
            NetworkNode source,
            NetworkNode destination,
            string data)
        {
            Id = id;
            Source = source;
            Destination = destination;
            Data = data;
        }
    }
}