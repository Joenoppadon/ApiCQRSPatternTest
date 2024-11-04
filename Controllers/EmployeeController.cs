using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Commands;
using ApiCQRSPatternTest.Models;
using ApiCQRSPatternTest.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiCQRSPatternTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet] //use postman or other for test
        [HttpGet("~/GetEmployeesAsync")] //use swagger for test
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employees = await _mediator.Send(new GetEmployeeListQuery());
            return employees;
        }
    
        [HttpGet("~/GetEmployeeByIdAsync")]
        public async Task<Employee> GetEmployeeByIdAsync(string empid)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery() { empid = empid });
        }

        [HttpPost("~/AddEmployeeAsync")]
        public async Task<object> AddEmployeeAsync(AddEmployee employee)
        {
            var newemployee = await _mediator.Send(new AddEmployeeCommand(
                employee.Empno,
                employee.Firstname,
                employee.Lastname,
                employee.Position,
                employee.Salary,
                employee.Deptno
            ));
            return newemployee;
        }

        [HttpPatch("~/UpdateEmployeeAsync")]
        public async Task<object> UpdateEmployeeAsync(Employee employee)
        {
            var updateemployee = await _mediator.Send(new UpdateEmployeeCommand(
                employee.Empno,
                employee.Firstname,
                employee.Lastname,
                employee.Position,
                employee.Salary,
                employee.Commission,
                employee.Deptno
            ));

            return updateemployee;
        }

        [HttpDelete("~/DeleteEmployeeAsync")]
        public async Task<object> DeleteEmployeeAsync(string empid)
        {
            return await _mediator.Send(new DeleteEmployeeCommand() { empid = empid });
        }

    }

}