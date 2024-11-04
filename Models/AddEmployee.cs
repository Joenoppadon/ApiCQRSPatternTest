using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRSPatternTest.Models
{
    public class AddEmployee
    {
        public string Empno { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public int Deptno { get; set; }
    }
}