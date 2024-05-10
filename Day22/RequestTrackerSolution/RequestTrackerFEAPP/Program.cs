using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.Exceptions;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        Employee? LoggedInEmployee = null;
        EmployeeLoginBL EmployeeLoginBL = new EmployeeLoginBL();

        async Task LoginEmployee (int userID, string password)
        {
            Employee employee = new Employee()
            {
                Id = userID,
                Password = password
            };

            try
            {
                LoggedInEmployee = await EmployeeLoginBL.Login(employee);
            } catch (EmployeeNotFoundException enfe)
            {
                Console.WriteLine(enfe.Message);
            }
        }

        async Task GetUserIDAndPassword ()
        {
            Console.Write("\nEnter your user id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter your password: ");
            string password = Console.ReadLine() ?? "";

            await LoginEmployee(userId, password);
        }

        static async Task Main(string[] args)
        {
           Program program = new Program();

           // get login credentials
           await program.GetUserIDAndPassword();

            // printing loggedin user
            Console.WriteLine(program.LoggedInEmployee);
        }
    }
}
