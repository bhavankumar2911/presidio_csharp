import re

name = input("Hi, may I have your name? ")
age = input("Hi {}, how old are you? ".format(name))
dob = input("When were you born? ")
phone = input("Not too old! Can I have your phone number? ")

errors = []

def validate():
    if (not re.fullmatch("^[A-Za-z\\s]+$", name)):
        errors.append("Name can have only alphabets and spaces!")
    if (not re.fullmatch("^[0-9]*$", age)):
        errors.append("Age should only be a number.")
    if (not re.fullmatch("^(3[01]|[12][0-9]|0?[1-9])(\/|-)(1[0-2]|0?[1-9])\2([0-9]{2})?[0-9]{2}$", dob)):
        errors.append("Date of birth is not valid")
    if (not re.fullmatch("^[+]{1}(?:[0-9\-\\(\\)\\/.]\s?){6,15}[0-9]{1}$", phone)):
        errors.append("Phone number is not valid. Kindly enter with country code.")

def printDetails():
    print("***********************")
    print("Name         : {}".format(name))
    print("Age          : {}".format(age))
    print("Date of birth: {}".format(dob))
    print("Phone number : {}".format(phone))

validate()

if (len(errors) == 0):
    printDetails()
else:
    for error in errors:
        print(error)