name = input("Hi, who are you? ")

print("1. Male")
print("2. Female")
print("Choose your gender please: ")
gender = int(input())

def getSalutation ():
    if (gender == 1):
        return "Mr."
    else:
        return "Ms."

print("You're welcome {} {}!".format(getSalutation(), name))