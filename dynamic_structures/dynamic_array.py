class DynamicArray:
    def __init__(self):
        self.array = []
    
    def add(self, item):
        self.array.append(item)

    def get(self, index):
        if 0 <= index < len(self.array):
            return self.array[index]
        return None

# Example
da = DynamicArray()
da.add(1)
da.add(2)
print(da.get(1))  # Output: 2
