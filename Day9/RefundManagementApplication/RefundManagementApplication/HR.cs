using RefundManagementBLLibrary;
using RefundManagementModelLibrary;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Net.Mail;

namespace RefundManagementApplication
{
    internal class HR
    {
        static EmployeeBL employeeService = new EmployeeBL();
        static RefundRequestBL refundRequestService = new RefundRequestBL();

        static int GetNumberFromUserUntilItIsValid(string ErrorMessage)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(ErrorMessage);
            }

            return number;
        }

        static float GetFloatingPointNumberFromUserUntilItIsValid(string ErrorMessage)
        {
            float number;

            while (!float.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(ErrorMessage);
            }

            return number;
        }

        static double GetDoubleNumberFromUserUntilItIsValid(string ErrorMessage)
        {
            double number;

            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(ErrorMessage);
            }

            return number;
        }

        static string GetPasswordFromUser()
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write('*');
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }

        static string GetStringFromUserUntilItIsEmpty(string errorMessage)
        {
            while (true)
            {
                string str = Console.ReadLine() ?? "";

                if (!string.IsNullOrEmpty(str)) { return str; }

                Console.WriteLine(errorMessage);
            }
        }

        static bool AuthenticateHR ()
        {
            Console.Write("\n Enter your password: ");
            string password = GetPasswordFromUser();

            return password == Environment.GetEnvironmentVariable("hr_password");
        }

        static Gender GetGenderFromUser ()
        {
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Prefer not to say\n");

            Console.Write("Kindly select the gender ");

            int gender = GetNumberFromUserUntilItIsValid("Option must be an integer");

            while (true)
            {
                switch (gender)
                {
                    case 1:
                        return Gender.Male;
                    case 2:
                        return Gender.Female;
                    case 3:
                        return Gender.PreferNotToSay;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        gender = GetNumberFromUserUntilItIsValid("Option must be an integer");
                        break;
                }
            }
        }

        static RequestStatus GetRequestStatusFromUser()
        {
            Console.WriteLine("1. Approve");
            Console.WriteLine("2. Reject");

            Console.Write("Kindly select the status ");

            int status = GetNumberFromUserUntilItIsValid("Option must be an integer");

            while (true)
            {
                switch (status)
                {
                    case 1:
                        return RequestStatus.Approved;
                    case 2:
                        return RequestStatus.Rejected;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        status = GetNumberFromUserUntilItIsValid("Option must be an integer");
                        break;
                }
            }
        }

        static RequestType GetRequestTypeByUser ()
        {
            Console.WriteLine("1. Educational");
            Console.WriteLine("2. Medical");
            Console.WriteLine("3. Travel");
            Console.WriteLine("4. Work supplies or tools");
            Console.WriteLine("5. Miscellaneous\n");

            Console.Write("Kindly select the Request type: ");

            int gender = GetNumberFromUserUntilItIsValid("Option must be an integer");

            while (true)
            {
                switch (gender)
                {
                    case 1:
                        return RequestType.Education;
                    case 2:
                        return RequestType.Medical;
                    case 3:
                        return RequestType.Travel;
                    case 4:
                        return RequestType.WorkSuppliesAndTools;
                    case 5:
                        return RequestType.Miscellaneous;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        gender = GetNumberFromUserUntilItIsValid("Option must be an integer");
                        break;
                }
            }
        }

        static string GetEmailAddressFromUserUntilItIsValid ()
        {
            string email = GetStringFromUserUntilItIsEmpty("Employee email is required!");
            MailAddress emailAddress;

            while (true)
            {
                try
                {
                    emailAddress = new MailAddress(email);
                    break;
                }
                catch
                {
                    Console.Write("\nKindly enter a valid email address: ");
                    email = GetStringFromUserUntilItIsEmpty("Employee email is required!");
                }
            }

            return email;
        }

        static Employee GetEmployeeDetailsAndCreateNewEmployee ()
        {
            Console.WriteLine("\nEnter employee details");

            Console.Write("\nEnter name: ");
            string name = GetStringFromUserUntilItIsEmpty("Employee name is required!");

            Console.Write("\nEnter gender: ");
            Gender gender = GetGenderFromUser();

            Console.Write("\nEnter age: ");
            float age = GetFloatingPointNumberFromUserUntilItIsValid("Age must be an integer or a decimal number");

            Console.Write("\nEnter email: ");
            string email = GetEmailAddressFromUserUntilItIsValid();

            Console.Write("\nEnter password: ");
            string password = GetPasswordFromUser();

            Employee employee = new Employee(name, gender, age, email, password);

            return employee;
        }

        static void DisplayAllEmployees ()
        {
            List<Employee> employees = employeeService.GetAllEmployee();

            foreach (var employee in employees)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Gender: {employee.GetGenderInString()}");
                Console.WriteLine($"Age: {employee.Age}");
                Console.WriteLine($"Email address: {employee.Email}");
            }
        }

        static void DisplayAllRefundRequestsToScreen ()
        {
            List<RefundRequest> refundRequests = refundRequestService.GetAllRefundRequests();

            foreach (var request in refundRequests)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Request id: {request.Id}");
                Console.WriteLine($"Request type: {request.RequestType}");
                Console.WriteLine($"Description: {request.Description}");
                Console.WriteLine($"Request status: {request.RequestStatus}");
                Console.WriteLine($"Raised Date: {request.Date}");
                Console.WriteLine($"Raised By: {request.RaisedBy.Name} ({request.RaisedBy.Email})");
                Console.WriteLine($"Amount claimed: {request.Amount}");
                if (request.RequestStatus == RequestStatus.Rejected)
                    Console.WriteLine($"Reason for rejection: {request.RejectionReason}");
            }
        }

        static void DisplayTheRequestsOfTheUserToScreen(int employeeId)
        {
            List<RefundRequest> requests = refundRequestService.GetAllRefundRequestsOfAUser(employeeId);

            foreach (var request in requests)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine($"Request id: {request.Id}");
                Console.WriteLine($"Request type: {request.RequestType}");
                Console.WriteLine($"Description: {request.Description}");
                Console.WriteLine($"Request status: {request.RequestStatus}");
                Console.WriteLine($"Raised Date: {request.Date}");
                Console.WriteLine($"Amount claimed: {request.Amount}");
                if (request.RequestStatus == RequestStatus.Rejected)
                    Console.WriteLine($"Reason for rejection: {request.RejectionReason}");
            }
        }

        static void UpdateTheRequestStatus ()
        {
            Console.Write("\nEnter the request id: ");
            int requestId = GetNumberFromUserUntilItIsValid("Request id must be a number");

            RefundRequest refundRequest = refundRequestService.GetOneRefundRequestById(requestId);

            Console.WriteLine("\nSelect the new request status: ");
            RequestStatus requestStatus = GetRequestStatusFromUser();

            if (requestStatus == RequestStatus.Rejected)
            {
                Console.WriteLine("\nKindly give the reason for the rejection: ");
                string rejectionReason = GetStringFromUserUntilItIsEmpty("Reason is required to reject a request. Kindly enter again");
                refundRequest.RejectionReason = rejectionReason;
            }

            refundRequestService.UpdateRefundRequestStatus(refundRequest, requestStatus);
        }

        static void HandleHROperations ()
        {
            if (!AuthenticateHR())
            {
                throw new HRAccessDeniedException();
            }
            while (true)
            {
                Console.WriteLine("\n0. Logout");
                Console.WriteLine("1. Add new Employee");
                Console.WriteLine("2. Show all Employee");
                Console.WriteLine("3. Show all Refund Requests");
                Console.WriteLine("4. Update request status");

                Console.Write("Kindly select the operation: ");

                int operation = GetNumberFromUserUntilItIsValid("Operation must be an integer");

                if (operation == 0) break;

                switch (operation)
                {
                    case 1:
                        try
                        {
                            Employee newEmployee = GetEmployeeDetailsAndCreateNewEmployee();
                            employeeService.CreateEmployeeAccount(newEmployee);
                            Console.WriteLine("\nEmployee added!");
                        }
                        catch (EmailAddressAlreadyInUseException eaaiu)
                        {
                            Console.WriteLine(eaaiu.Message);
                        }
                        break;
                    case 2:
                        DisplayAllEmployees();
                        break;
                    case 3:
                        try
                        {
                            DisplayAllRefundRequestsToScreen();
                        } catch (NoRefundRequestsException nrre)
                        {
                            Console.WriteLine(nrre.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            UpdateTheRequestStatus();
                        } catch (RequestNotFoundException rnfe)
                        {
                            Console.WriteLine(rnfe.Message);
                        }
                        break;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        break;
                }
            }
        }

        static RefundRequest CreateNewRefundRequest (Employee employee)
        {
            Console.WriteLine("\nSelect request type from the options: ");
            RequestType requestType = GetRequestTypeByUser();

            Console.WriteLine("Enter description about the refund request: ");
            string description = GetStringFromUserUntilItIsEmpty("Description is required. Enter again");

            Console.Write("Enter the amount you've spent: ");
            double amount = GetDoubleNumberFromUserUntilItIsValid("Amount must be a number");

            RefundRequest refundRequest = new RefundRequest(requestType, amount, employee, description);

            return refundRequest;
        }

        static void HandleEmployeeOperations ()
        {
            Console.Write("\nEnter email address: ");
            string email = GetEmailAddressFromUserUntilItIsValid();

            Console.Write("\nEnter password: ");
            string password = GetPasswordFromUser();

            Employee employee = employeeService.LogInEmployee(email, password);

            while (true)
            {
                Console.WriteLine("\n0. Logout");
                Console.WriteLine("1. Raise a refund request");
                Console.WriteLine("2. Check all requests' status");

                Console.Write("Kindly select the operation: ");

                int operation = GetNumberFromUserUntilItIsValid("Operation must be an integer");

                if (operation == 0) break;

                switch (operation)
                {
                    case 1:
                        RefundRequest newRefundRequest = CreateNewRefundRequest(employee);
                        refundRequestService.RaiseRefundRequest(newRefundRequest);
                        break;
                    case 2:
                        try
                        {
                            DisplayTheRequestsOfTheUserToScreen(employee.Id);
                        } catch (NoRefundRequestsException nrre)
                        {
                            Console.WriteLine(nrre.Message);
                        }
                        break;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        break;
                }
            }
        }

        static void PrintMenu ()
        {
            while (true)
            {
                Console.WriteLine("\n****** Refund Management System ******\n");

                Console.WriteLine("1. HR Manager");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Exit Application\n");

                Console.Write("Kindly select the user type: ");

                int userType = GetNumberFromUserUntilItIsValid("Option must be an integer");

                switch (userType)
                {
                    case 1:
                        try
                        {
                            HandleHROperations();
                        }
                        catch (HRAccessDeniedException hred)
                        {
                            Console.WriteLine($"\n{hred.Message}");
                        }

                        break;
                    case 2:
                        try
                        {
                            HandleEmployeeOperations();
                        }
                        catch (EmployeeNotFoundException enfe)
                        {
                            Console.WriteLine($"\n{enfe.Message}");
                        }
                        catch (WrongEmployeeCredentialsException wece)
                        {
                            Console.WriteLine($"\n{wece.Message}");
                        }

                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write("Kindly choose a valid option! ");
                        userType = GetNumberFromUserUntilItIsValid("Option must be an integer");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            
            //IEmployeeService employeeService = new EmployeeBL();
            //IRefundRequestService refundRequestService = new RefundRequestBL();

            //PrintMenu(employeeService,refundRequestService);

            PrintMenu();
        }
    }
}
