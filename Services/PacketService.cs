using NetLab.Models;

namespace NetLab.Services
{
    public class PacketService
    {
        public void SendPacket(
            Packet packet,
            List<NetworkNode> route)
        {
            Console.WriteLine("=== Packet Simulation ===");

            Console.WriteLine($"Packet ID: {packet.Id}");
            Console.WriteLine($"Data: {packet.Data}");
            Console.WriteLine(
                $"Source: {packet.Source.Name}");
            Console.WriteLine(
                $"Destination: {packet.Destination.Name}");

            Console.WriteLine();
            Console.WriteLine("Packet Route:");

            for (int i = 0; i < route.Count; i++)
            {
                Console.WriteLine(
                    $"Hop {i + 1}: {route[i].Name}");
            }

            Console.WriteLine();
            Console.WriteLine("Packet delivered successfully!");
        }
    }
}