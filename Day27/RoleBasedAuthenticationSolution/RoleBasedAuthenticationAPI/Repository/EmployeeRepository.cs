using Microsoft.EntityFrameworkCore;
using RoleBasedAuthenticationAPI.Context;
using RoleBasedAuthenticationAPI.Models;
using RoleBasedAuthenticationAPI.Repository.Interfaces;

namespace RoleBasedAuthenticationAPI.Repository
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly RoleBasedAuthContext _context;

        public EmployeeRepository(RoleBasedAuthContext context)
        {
            _context = context;
        }

        async public Task<Employee> Add(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        async public Task<Employee> Delete(int key)
        {
            var employee = await GetByKey(key);

            if (employee != null)
            {
                _context.Remove(employee);
                await _context.SaveChangesAsync(true);
                return employee;
            }

            throw new Exception($"Employee with id - {key} not found");
        }

        async public Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetByKey(int key)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == key);

            if (employee != null) return employee;

            throw new Exception($"Employee with id - {key} not found");
        }

        async public Task<Employee> Update(Employee newEmployee)
        {
            var employee = await GetByKey(newEmployee.Id);

            if (employee != null)
            {
                _context.Update(newEmployee);
                await _context.SaveChangesAsync(true);
                return newEmployee;
            }

            throw new Exception($"Employee with id - {newEmployee.Id} not found");
        }
    }

}
