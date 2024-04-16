using System.Xml.Linq;

namespace CompanyModelLibrary
{
    public class Company
    {
        public int CasualLeavePerYear { get; set; }
        public int SickLeavePerYear { get; set; }
        public int PrivilegeLeavePerYear { get; set; }
        public double EmployeePFContribution { get; set; }
        public double EmployerPFContribution { get; set; }

        public virtual double CalculateGratuityAmount (float serviceCompleted, double basicSalary)
        {
            return 0;
        }
    }
}
