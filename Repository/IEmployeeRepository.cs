using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Models;

namespace ApiCQRSPatternTest.Repository
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeeListAsync();

        public Task<Employee> GetEmployeeByIdAsync(string empid);

        public Task<object> AddEmployeeAsync(Employee employee);
        public Task<object> UpdateEmployeeAsync(Employee employee);

        public Task<object> DeleteEmployeeAsync(string empid);
    }
}