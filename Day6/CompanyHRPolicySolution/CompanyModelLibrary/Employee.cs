using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    public class Employee: IGovtRules
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Department { get; set; }
        //public string Designation { get; set; }
        //public double BasicSalary { get; set; }
        public double YearsServed { get; set; }
        public Company Employer { get; set; }

        public Employee(double yearsServed, string employer)
        {
            //Name = name;
            //Department = department;
            //Designation = designation;
            //BasicSalary = basicSalary;
            YearsServed = yearsServed;

            if (employer == "CTS")
                Employer = new CTS();
            else
                Employer = new Accenture();
        }

        public double EmployeePF(double basicSalary)
        {
            return (0.12 * basicSalary);
        }

        public string LeaveDetails()
        {
            string leaveDetails = $"CasualLeavePerYear: {Employer.CasualLeavePerYear}\nSickLeavePerYear: {Employer.SickLeavePerYear}\nPrivilegeLeavePerYear: {Employer.PrivilegeLeavePerYear}\n";
            return leaveDetails;
        }

        public double GratuityAmount(float serviceCompleted, double basicSalary)
        {
            return Employer.CalculateGratuityAmount(serviceCompleted, basicSalary);
        }
    }
}
