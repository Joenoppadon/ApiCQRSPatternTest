using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Models;
using ApiCQRSPatternTest.Query;
using ApiCQRSPatternTest.Repository;
using MediatR;

namespace ApiCQRSPatternTest.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(request.empid);
        }
    }
}