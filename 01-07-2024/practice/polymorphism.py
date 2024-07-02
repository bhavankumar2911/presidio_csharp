class Animal:
    def print_details(self):
        print("I am a living thing")
    
class Dog(Animal):
    def print_details(self):
        print("I am dog, an animal")

class Cat(Animal):
    pass

animal = Animal()
dog = Dog()
cat = Cat()

animal.print_details()
dog.print_details()
cat.print_details()