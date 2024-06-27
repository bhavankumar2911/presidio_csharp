name = input("Hi, may I have your name? ")
age = int(input("Hi {}, how old are you? ".format(name)))
dob = input("When were you born? ")
phone = input("Not too old! Can I have your phone number? ")

def printDetails():
    print("***********************")
    print("Name         : {}".format(name))
    print("Age          : {}".format(age))
    print("Date of birth: {}".format(dob))
    print("Phone number : {}".format(phone))

printDetails()