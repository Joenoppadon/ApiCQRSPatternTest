using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Data;
using ApiCQRSPatternTest.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


namespace ApiCQRSPatternTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        private readonly IValidator<Employee> _empvalidator;

        public EmployeeRepository(DataContext dataContext, IValidator<Employee> empvalidator)
        {
            _dataContext = dataContext;
            _empvalidator = empvalidator;
        }

        public async Task<object> AddEmployeeAsync(Employee employee)
        {
            var validator = await _empvalidator.ValidateAsync(employee);
            if (!validator.IsValid) return validator.Errors;

            //var result = _dataContext.Employee.Add(employee);
            _dataContext.Employee.Add(employee);
            await _dataContext.SaveChangesAsync();
            //return result.Entity;
            return new { status = "Add employee success" };

        }

        public async Task<object> DeleteEmployeeAsync(string empid)
        {
            var employee = _dataContext.Employee.Where(m => m.Empno.Equals(empid)).FirstOrDefault();
            if (employee == null) return new { status = "Employee not found!" };
            _dataContext.Employee.Remove(employee);
            await _dataContext.SaveChangesAsync();
            return new { status = "Delete Success" };
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empid)
        {
            return await _dataContext.Employee.Where(m => m.Empno.Equals(empid)).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            // var employee = from emp in _dataContext.Employee
            //                 select emp;

            return await _dataContext.Employee.ToListAsync();
        }

        public async Task<object> UpdateEmployeeAsync(Employee employee)
        {
            var findemployee = await _dataContext.Employee.FindAsync(employee.Empno);
            if (findemployee == null) return new { status = "Employee not found!" };

            //ควร validation employee ด้วยแต่ผมขี้เกรียจเขียนไปดูตัวอย่างที่ Models > Validation ได้เลย ^_^

            findemployee.Firstname = employee.Firstname;
            findemployee.Lastname = employee.Lastname;
            findemployee.Position = employee.Position;
            findemployee.Salary = employee.Salary;
            findemployee.Commission = employee.Commission;
            findemployee.Deptno = employee.Deptno;

            //var result = _dataContext.Employee.Update(employee);
            _dataContext.Employee.Update(findemployee);
            await _dataContext.SaveChangesAsync();
            //return result.Entity;
            return new { status = "Update success" };
        }
    }
}