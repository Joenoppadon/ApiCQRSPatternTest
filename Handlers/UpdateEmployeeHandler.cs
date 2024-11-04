using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Commands;
using ApiCQRSPatternTest.Models;
using ApiCQRSPatternTest.Repository;
using MediatR;

namespace ApiCQRSPatternTest.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, object>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<object> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(){
                Empno = request._Empno,
                Firstname = request._Firstname,
                Lastname = request._Lastname,
                Position = request._Position,
                Salary = request._Salary,
                Commission = request._Commission,
                Deptno = request._Deptno

            };
            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}