# NetLab

A C# network simulation project that models network topology, routing algorithms, packet transmission, and network statistics.

NetLab was built to apply **Object-Oriented Programming, Data Structures, Algorithms, and Computer Networks concepts** in a practical simulation environment.

---

## Features

- Network node management
- Bidirectional network connections
- Connection cost/weight support
- Network topology visualization
- BFS path finding
- DFS path finding
- Dijkstra shortest-path routing
- Packet creation and transmission simulation
- Packet route visualization
- Network statistics
- Average node degree calculation
- Maximum node degree calculation

---

## Technologies

- **Language:** C#
- **Framework:** .NET 10
- **Application Type:** Console Application
- **IDE:** Visual Studio 2022

---

## Algorithms

### BFS — Breadth-First Search

Finds a path between two nodes using breadth-first traversal.

Useful for exploring network connectivity and finding paths based on the number of hops.

### DFS — Depth-First Search

Explores the network using depth-first traversal.

Useful for graph exploration and connectivity analysis.

### Dijkstra's Algorithm

Calculates the shortest path between two nodes based on connection costs.

Example:

```text
A → C → B → D
2 + 1 + 5 = 8

Packet Simulation

NetLab simulates the transmission of a packet across the network.

Example:

Packet ID: P001
Source: A
Destination: D

Packet Route:
A
↓
C
↓
B
↓
D

The packet follows the shortest route calculated by Dijkstra's algorithm.

Network Topology

Example network:

A ──4── B ──5── D
│      │
2      1
│      │
C ──8──┘

The network supports bidirectional connections, so each connection can be traversed in both directions.

Network Statistics

NetLab calculates basic network statistics including:

Number of nodes
Number of connections
Average degree
Maximum degree

Example:

Nodes: 4
Connections: 5
Average Degree: 2.50
Maximum Degree: 3
Project Structure
NetLab/
│
├── Algorithms/
│   ├── BFSAlgorithm.cs
│   ├── DFSAlgorithm.cs
│   └── DijkstraAlgorithm.cs
│
├── Models/
│   ├── NetworkNode.cs
│   ├── Connection.cs
│   ├── NetworkGraph.cs
│   └── Packet.cs
│
├── Services/
│   ├── NetworkService.cs
│   ├── PacketService.cs
│   └── NetworkStatistics.cs
│
└── Program.cs
Architecture

The project follows a simple layered structure:

Models

Contains the core data structures used by the simulation.

Examples:

NetworkNode
Connection
NetworkGraph
Packet
Algorithms

Contains graph and routing algorithms.

Examples:

BFSAlgorithm
DFSAlgorithm
DijkstraAlgorithm
Services

Contains application logic for managing the network, simulating packets, and calculating statistics.

Examples:

NetworkService
PacketService
NetworkStatistics
Concepts Applied

This project demonstrates practical usage of:

Object-Oriented Programming
Classes and Objects
Encapsulation
Collections
List<T>
Dictionary<TKey,TValue>
HashSet<T>
Queue<T>
Graphs
Graph Traversal
Shortest Path Algorithms
Network Routing
Packet Simulation
Basic Network Analysis
Example Output
================================
          NETLAB SIMULATOR
================================

=== Network Topology ===
A: B(4) C(2)
B: A(4) C(1) D(5)
C: A(2) B(1) D(8)
D: B(5) C(8)

=== Routing Algorithms ===
BFS: A -> B -> D
DFS: A -> B -> C -> D
Dijkstra: A -> C -> B -> D
Shortest Cost: 8

=== Packet Simulation ===
Packet ID: P001
Data: Hello from A to D
Source: A
Destination: D

Packet Route:
Hop 1: A
Hop 2: C
Hop 3: B
Hop 4: D

Packet delivered successfully!

=== Network Statistics ===
Nodes: 4
Connections: 5
Average Degree: 2.50
Maximum Degree: 3
Future Improvements

Possible future extensions:

Interactive command-line network builder
Router and switch entities
Packet loss simulation
Network latency simulation
Bandwidth simulation
Routing table generation
Multiple packet simulation
Network failure simulation
Network performance benchmarking
Visualization of network graphs
Purpose

NetLab was created as a practical project for applying computer science concepts to a simulated networking environment.

The project combines C#, OOP, Data Structures, Algorithms, and Computer Networks into a single system.