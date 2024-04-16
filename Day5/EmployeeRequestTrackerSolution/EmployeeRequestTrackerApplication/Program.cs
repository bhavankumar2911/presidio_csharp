using EmpolyeeRequestTrackerModelLibrary;

namespace EmployeeRequestTrackerApplication
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[2];
        }
        void UpdateEmployeeName ()
        {   
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);

            Console.WriteLine("*************************Before Updation*************************");
            employee.PrintEmployeeDetails();

            Console.Write("Enter the new name for the Employee: ");
            string newName = Console.ReadLine() ?? "";

            while (newName == string.Empty)
            {
                Console.Write("Employee  name cannot be empty. Please enter again: ");
                newName = Console.ReadLine() ?? "";
            }

            employee.Name = newName;

            Console.WriteLine("*************************After Updation*************************");
            employee.PrintEmployeeDetails();
        }
        void DeleteEmployee ()
        {
            int id = GetIdFromConsole ();
            Employee employee = SearchEmployeeById(id);

            Employee[] newEmployeeList = new Employee[employees.Length];
            int newIndex = 0;

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i].Id != id)
                {
                    newEmployeeList[newIndex++] = employees[i];  
                }
            }

            employees = newEmployeeList;

            Console.WriteLine("****************************************************");
            Console.WriteLine($"Employee list after deleting \"{employee.Name}\"");
            Console.WriteLine("****************************************************");
            PrintAllEmployees();
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Update an Employee's name");
            Console.WriteLine("5. Delete an Employee");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        UpdateEmployeeName();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            Console.WriteLine("Please enter the type of employee");
            string type = Console.ReadLine();
            if (type == "Permanent")
                employee = new PermanentEmployee();
            else if (type == "Contract")
                employee = new ContractEmployee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int GetIdFromConsole()
        {
            int id = 0;
            Console.WriteLine("Please enter the employee Id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }
            PrintEmployee(employee);
        }
        Employee SearchEmployeeById(int id)
        {
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
        }
    }
}
