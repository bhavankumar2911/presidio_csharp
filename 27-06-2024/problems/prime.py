import math

number = int(input('Enter a number: '))

def checkIsPrime():
    for i in range(2, int(math.sqrt(number)) + 1):
        if (number % i == 0):
            return False
    return True

if (checkIsPrime()):
    print("{} is a prime number".format(number))
else:
    print("{} is a composite number.".format(number))