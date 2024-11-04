using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Models;
using MediatR;

namespace ApiCQRSPatternTest.Commands
{
    public class AddEmployeeCommand : IRequest<object>
    {
        public string _Empno { get; set; }
        public string _Firstname { get; set; }
        public string _Lastname { get; set; }
        public string _Position { get; set; }
        public decimal _Salary { get; set; }
        public int _Deptno { get; set; }
        public AddEmployeeCommand(string Empno,string Firstname,string Lastname,string Position
                                ,decimal Salary,int Deptno)
        {
            _Empno = Empno;
            _Firstname = Firstname;
            _Lastname = Lastname;
            _Position = Position;
            _Salary = Salary;
            _Deptno = Deptno;
        }
    }
}