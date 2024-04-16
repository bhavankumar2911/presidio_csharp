using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    public class CTS : Company
    {
        
        public CTS()
        {
            CasualLeavePerYear = 12;
            SickLeavePerYear = 12;
            PrivilegeLeavePerYear = 10;
            EmployerPFContribution = 3.67;
            EmployeePFContribution = 8.33;
        }

        public override double CalculateGratuityAmount(float serviceCompleted, double basicSalary)
        {
            if (serviceCompleted > 20)
            {
                return basicSalary * 3;
            }

            if (serviceCompleted > 10)
            {
                return (basicSalary * 2);
            }

            if (serviceCompleted > 5)
            {
                return (basicSalary / 12);
            }

            return 0;
        }
    }
}
