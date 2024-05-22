using Microsoft.EntityFrameworkCore;
using RoleBasedAuthenticationAPI.Models;
using RoleBasedAuthenticationAPI.Repository.Interfaces;
using RoleBasedAuthenticationAPI.Repository;
using RoleBasedAuthenticationAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoleBasedAuthenticationAPI.Context;
using RoleBasedAuthenticationAPI.Services;

namespace RoleBasedAuthTest
{
    internal class EmployeeRepositoryTest
    {
        RoleBasedAuthContext context;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder().UseInMemoryDatabase("dummyDB");
            context = new RoleBasedAuthContext(optionsBuilder.Options);
        }

        [Test]
        public async Task GetEmployeeTest()
        {
            //Arrange
            IRepository<int, Employee> employeeRepo = new EmployeeRepository(context);

            Employee employee = await employeeRepo.Add(new Employee
            {
                Name = "test employee",
                Age = 21,
                Role = "user",
                Email = "test@gmail.com",
                IsActive = true,
            });

            //Assert
            Assert.IsNotNull(employee);

        }
    }
}
