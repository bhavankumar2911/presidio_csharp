def greet():
    print("Welcome")

def greetName(name):
    print(f"Welcome {name}")

def getGreet():
    return "Welcome"

def defaultGreeting(name = 'buddy'):
    print(f"Welcome {name}")

def sumCalc(*nums):
    sum = 0
    for n in nums:
        sum += n
    print(sum)

greet()
greetName("bhavan")
print(getGreet())
defaultGreeting()
defaultGreeting("Bhavan")
sumCalc(1, 2, 3, 4, 5)