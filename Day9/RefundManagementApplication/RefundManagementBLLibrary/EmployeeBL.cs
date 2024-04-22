using RefundManagementDALLibrary;
using RefundManagementModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefundManagementBLLibrary
{
    internal class EmployeeBL : IEmployeeService
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
            }

            allEmployees.Add(newEmployee);

            return newEmployee;
        }
    }
}
