using RefundManagementDALLibrary;
using RefundManagementModelLibrary;

namespace RefundManagementTest
{
    public class EmployeeRepositoryTest
    {
        EmployeeRepository EmployeeRepository;

        [SetUp]
        public void Setup()
        {
            EmployeeRepository = new EmployeeRepository();
        }

        [TestCase("bhavan", Gender.Male, 21, "bhavan@gmail.com", "pass")]
        [TestCase("ritu", Gender.Female, 21, "ritu@gmail.com", "pass")]
        public void AddEmployeeSuccessTest(string name, Gender gender, float age, string email, string password)
        {
            Employee e1 = new Employee(name,gender,age,email,password);

            EmployeeRepository.Add(e1);


            Assert.AreEqual(EmployeeRepository.GetAll().Count, 2);
        }
    }
}