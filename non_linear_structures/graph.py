class Graph:
    def __init__(self):
        self.graph = {}

    def add_edge(self, node, neighbor):
        if node not in self.graph:
            self.graph[node] = []
        self.graph[node].append(neighbor)

    def display(self):
        for node in self.graph:
            print(f"{node} -> {self.graph[node]}")

# Example
g = Graph()
g.add_edge("A", "B")
g.add_edge("A", "C")
g.display()
# Output: A -> ['B', 'C']
