using RequestTrackerBLLibrary;
using RequestTrackerBLLibrary.Exceptions;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        RequestTrackerContext context = new RequestTrackerContext();
        Employee? LoggedInEmployee = null;
        EmployeeLoginBL EmployeeLoginBL;
        RequestBL RequestBL;

        public Program()
        {
            EmployeeLoginBL = new EmployeeLoginBL(context);
            RequestBL = new RequestBL(context); 
        }

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
                await GetUserIDAndPassword();
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

        void PrintEntityList (IList<Request> requests)
        {
            foreach (var request in requests)
            {
                Console.WriteLine(request);
            }
        }

        async Task RaiseNewRequest ()
        {
            Console.Write("\nEnter the issue: ");
            string issue = Console.ReadLine();

            Request request = new Request()
            {
                RequestMessage = issue
            };

            RequestBL.RaiseRequest(request, LoggedInEmployee.Id);
        }

        async Task AdminHandler (int option)
        {
            switch(option)
            {
                case 1:
                    await RaiseNewRequest();
                    break;
                case 2:
                    try
                    {
                        IList<Request> requests = await RequestBL.ViewAllRequests();
                        PrintEntityList(requests);
                    } catch (NoRequestsFoundException nrfe)
                    {
                        Console.WriteLine(nrfe.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        async Task PrintMenu ()
        {
            if (LoggedInEmployee.Role == "Admin")
            {
                Console.WriteLine("\nChoose an option: ");
                Console.WriteLine("\n1. Raise a request");
                Console.WriteLine("\n2. View all request status");
                Console.WriteLine("\n3. View all solutions");
                Console.WriteLine("\n4. Give feedback for a solution");
                Console.WriteLine("\n5. Respond to a solution");
                Console.WriteLine("\n6. Provide Solution");
                Console.WriteLine("\n7. Mark Request as Closed");
                Console.WriteLine("\n8. View Feedbacks");
                Console.Write("\nEnter the option: ");
                int option = Convert.ToInt32(Console.ReadLine());
                await AdminHandler(option);
            }
            else
            {
                Console.WriteLine("\nChoose an option: ");
                Console.WriteLine("\n1. Raise a request");
                Console.WriteLine("\n2. View request status");
                Console.WriteLine("\n3. View solutions");
                Console.WriteLine("\n4. Give feedback for a solution");
                Console.WriteLine("\n5. Respond to a solution");
                Console.Write("\nEnter the option: ");
                int option = Convert.ToInt32(Console.ReadLine());
            }
        }

        static async Task Main(string[] args)
        {
           Program program = new Program();

           // get login credentials
           await program.GetUserIDAndPassword();

           await program.PrintMenu();
        }
    }
}
