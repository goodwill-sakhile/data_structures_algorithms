class Node:
    def __init__(self, value):
        self.left = None
        self.right = None
        self.value = value

def inorder_traversal(node):
    if node:
        inorder_traversal(node.left)
        print(node.value, end=" ")
        inorder_traversal(node.right)

# Example
root = Node(10)
root.left = Node(5)
root.right = Node(15)
inorder_traversal(root)  # Output: 5 10 15
