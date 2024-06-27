rows = int(input('Enter the rows'))

for i in range(1, rows + 1):
    # spaces
    for j in range(1, (rows - i) + 1):
        print(" ", end="")
    
    # stars
    for j in range(1, (i * 2)):
        print("*", end="")

    print("")