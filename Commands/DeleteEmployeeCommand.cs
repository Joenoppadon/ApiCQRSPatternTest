using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ApiCQRSPatternTest.Commands
{
    public class DeleteEmployeeCommand : IRequest<object>
    {
        public string empid { get; set; }
    }
}