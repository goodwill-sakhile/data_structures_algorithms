def findTheSum(mult_one, multi_two, max_num):
    total_sum = 0
    for i in range(max_num):
        if ((i%mult_one == 0) or (i%multi_two == 0)):
            total_sum += i
    return total_sum
if __name__ == "__main__":
    findTheSum(3, 5, 10)
    
