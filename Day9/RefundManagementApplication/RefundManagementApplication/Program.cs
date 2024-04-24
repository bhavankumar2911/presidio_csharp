using RefundManagementBLLibrary;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementApplication
{
    public class Program
    {
        static EmployeeBL EmployeeBL = new EmployeeBL();   
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("bhavan", Gender.Male,21, "bhavan@gmail.com", "pass");
            Employee employee2 = new Employee("ritu", Gender.Female, 21, "ritu@gmail.com", "pass");

            EmployeeBL.CreateEmployeeAccount(employee1);
            EmployeeBL.CreateEmployeeAccount(employee2);

            List<Employee> employees = EmployeeBL.GetAllEmployee();

            foreach (var item in employees)
            {
                Console.WriteLine($"Name: {item.Name}");
            }
        }
    }
}
