using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyModelLibrary
{
    internal class Accenture: Company
    { 
        public Accenture()
        {
            CasualLeavePerYear = 24;
            SickLeavePerYear = 5;
            PrivilegeLeavePerYear = 5;
            EmployerPFContribution = 12;
            EmployeePFContribution = 0;
        }
    }
}
