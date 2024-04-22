using RefundManagementDALLibrary;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public Employee CreateEmployeeAccount(Employee newEmployee)
        {
            List<Employee>? allEmployees = _employeeRepository.GetAll();

            if (allEmployees != null)
            {
                foreach (var employee in allEmployees)
                {
                    if (employee.Email == newEmployee.Email) throw new EmailAddressAlreadyInUseException();
                }

                allEmployees.Add(newEmployee);
                return newEmployee;
            }

            allEmployees.Add(newEmployee);

            return newEmployee;
        }

        public Employee LogInEmployee(string email, string password)
        {
            List<Employee> allEmployees = _employeeRepository.GetAll();
            Employee employee = new Employee();
            bool isEmployeePresent = false;

            foreach (var currentEmployee in allEmployees)
            {
                if (currentEmployee.Email == email)
                {
                    isEmployeePresent = true;
                    employee = currentEmployee;
                    break;
                }
            }

            if (!isEmployeePresent) throw new EmployeeNotFoundException();  

            if (employee.Password != password) throw new WrongEmployeeCredentialsException();

            return employee;
        }

        public List<Employee> GetAllEmployee ()
        {
            return _employeeRepository.GetAll();
        }
    }
}
