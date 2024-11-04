using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Models;
using MediatR;

namespace ApiCQRSPatternTest.Query
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public string empid { get; set; }
    }
}