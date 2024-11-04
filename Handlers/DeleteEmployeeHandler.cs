using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Commands;
using ApiCQRSPatternTest.Repository;
using MediatR;

namespace ApiCQRSPatternTest.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, object>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<object> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(request.empid);
            if (employee == null) return new { status = "Employee not found!" };

            return await _employeeRepository.DeleteEmployeeAsync(employee.Empno);
        }
    }
}