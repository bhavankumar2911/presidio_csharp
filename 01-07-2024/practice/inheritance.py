class Organization:
    def __init__(self, name) -> None:
        self.organization_name = name

class Employee(Organization):
    def __init__(self, organization_name, employee_name) -> None:
        super().__init__(organization_name)
        self.employee_name = employee_name

    def print_employee_details(self):
        print(f"{self.employee_name} is working at {self.organization_name}")

employee = Employee("Presidio", "Bhavan")
employee.print_employee_details()
