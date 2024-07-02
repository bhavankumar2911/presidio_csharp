class Employee:
    def __init__(self, name, organization) -> None:
        self.name = name
        self.organization = organization

    def print_employee_details(self):
        print(f"{self.name} is working at {self.organization}")

employee1 = Employee("Bhavan", "Presidio")
employee2 = Employee("Ritika", "Genspark")

employee1.print_employee_details()
employee2.print_employee_details()