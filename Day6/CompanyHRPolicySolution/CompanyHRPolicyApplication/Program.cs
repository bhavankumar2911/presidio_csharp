using CompanyModelLibrary;

namespace CompanyHRPolicyApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee(23, "CTS");
            Console.WriteLine("Employee PF: " + employee.EmployeePF(900000));
            Console.WriteLine("Leave Details:");
            Console.WriteLine(employee.LeaveDetails());
            Console.WriteLine("Gratuity Amount: " + employee.GratuityAmount(23, 900000));
        }
    }
}
