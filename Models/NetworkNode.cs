namespace NetLab.Models
{
    public class NetworkNode
    {
        public string Name { get; set; }

        public NetworkNode(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}