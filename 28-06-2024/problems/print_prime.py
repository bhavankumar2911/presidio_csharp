import math

totalNumbers = int(input("Enter the upper limit: "))

def checkIsPrime(number):
    for i in range(2, int(math.sqrt(number)) + 1):
        if (number % i == 0):
            return False
    return True

for number in range(1, totalNumbers):
    if (checkIsPrime(number)):
        print(number)