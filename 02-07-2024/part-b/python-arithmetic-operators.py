def perform_operations(a, b):
    # Calculate sum
    sum_ab = a + b
    # Calculate difference (a - b)
    diff_ab = a - b
    # Calculate product
    prod_ab = a * b
    
    # Print results
    print(sum_ab)
    print(diff_ab)
    print(prod_ab)

if __name__ == '__main__':
    a = int(input())
    b = int(input())
    
    perform_operations(a, b)