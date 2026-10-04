# NetLab Architecture

## 1. Overview

NetLab is organized using a simple layered architecture that separates:

- Data models
- Algorithms
- Application services
- Program entry point

This separation makes the project easier to understand, test, and extend.

---

## 2. Architecture Diagram

```text
                    ┌──────────────────┐
                    │    Program.cs    │
                    │   Application    │
                    │     Entry Point  │
                    └────────┬─────────┘
                             │
                ┌────────────┼────────────┐
                │            │            │
                ▼            ▼            ▼
       ┌─────────────┐ ┌─────────────┐ ┌─────────────┐
       │  Services   │ │  Algorithms │ │   Models    │
       └──────┬──────┘ └──────┬──────┘ └─────────────┘
              │               │
              └───────────────┘
                      │
                      ▼
               Network Graph

3. Models Layer

The Models folder contains the core entities used by the simulator.

NetworkNode

Represents a device or node in the network.

NetworkNode
├── Name
└── Node identity
Connection

Represents a connection between two network nodes.

Connection
├── From
├── To
└── Cost

The cost represents the weight of the connection and is used by Dijkstra's algorithm.

NetworkGraph

Stores the network topology using an adjacency-list representation.

Dictionary<NetworkNode, List<Connection>>

This allows the application to efficiently access the connections associated with each node.

Packet

Represents data moving through the simulated network.

Packet
├── Id
├── Source
├── Destination
└── Data
4. Algorithms Layer

The Algorithms folder contains graph traversal and routing algorithms.

BFSAlgorithm

Breadth-First Search explores the network level by level.

It is useful for finding a path based primarily on the number of hops.

Start
  │
  ├── Neighbor 1
  ├── Neighbor 2
  └── Neighbor 3
DFSAlgorithm

Depth-First Search explores one branch as deeply as possible before backtracking.

It is useful for graph traversal and connectivity exploration.

DijkstraAlgorithm

Dijkstra's algorithm calculates the minimum-cost path between two nodes.

It uses connection costs to compare possible routes.

Example:

A → C → B → D

Cost:
2 + 1 + 5 = 8
5. Services Layer

The Services folder contains application-level operations.

NetworkService

Responsible for managing the network.

Main responsibilities:

Add nodes
Add connections
Remove connections
Remove nodes
Display network topology

Connections are currently bidirectional.

For example:

A ↔ B

Adding a connection from A to B also creates the reverse connection from B to A.

PacketService

Responsible for simulating packet transmission.

It receives:

A packet
A calculated route

It then displays every hop in the packet's route.

Example:

A
↓
C
↓
B
↓
D
NetworkStatistics

Calculates basic network metrics.

Current metrics include:

Number of nodes
Number of connections
Average degree
Maximum degree
6. Data Structure

NetLab uses an adjacency list to represent the graph.

A → B, C
B → A, C, D
C → A, B, D
D → B, C

The internal representation is based on:

Dictionary<NetworkNode, List<Connection>>

This structure is appropriate for sparse graphs and provides direct access to a node's neighbors.

7. Execution Flow

A typical execution follows this sequence:

1. Create NetworkGraph
        ↓
2. Create NetworkService
        ↓
3. Create Network Nodes
        ↓
4. Add Network Connections
        ↓
5. Display Network Topology
        ↓
6. Execute BFS / DFS / Dijkstra
        ↓
7. Calculate shortest path
        ↓
8. Create Packet
        ↓
9. Simulate Packet Transmission
        ↓
10. Calculate Network Statistics
8. Example Routing Scenario

Given the network:

A ──4── B ──5── D
│      │
2      1
│      │
C ──8──┘

Possible routes from A to D include:

A → B → D
Cost = 4 + 5 = 9

and:

A → C → B → D
Cost = 2 + 1 + 5 = 8

Dijkstra selects:

A → C → B → D

because its total cost is lower.

9. Design Principles

The project follows several basic software engineering principles:

Separation of Responsibilities

Each component has a specific responsibility.

Encapsulation

Network operations are handled by services instead of being scattered throughout the program.

Reusability

Algorithms are implemented independently from the main program, allowing them to be reused with different network structures.

Extensibility

New algorithms, network entities, and simulation features can be added without redesigning the entire project.

10. Future Architecture Extensions

The architecture can later be extended with:

Router and Switch models
Routing tables
Packet loss simulation
Latency simulation
Bandwidth simulation
Network failure detection
Dynamic topology changes
Performance benchmarking
Graph visualization
Interactive command-line interface
11. Conclusion

NetLab uses a modular architecture that combines network models, graph algorithms, and application services.

The current structure provides a solid foundation for extending the project into a more advanced network simulation platform.