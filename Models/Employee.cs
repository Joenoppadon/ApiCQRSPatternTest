using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCQRSPatternTest.Models
{
    public class Employee
    {
        public string Empno { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public DateOnly Hiredate { get;}

        public decimal Salary { get; set; }
        public decimal Commission { get; set; }
        public int Deptno { get; set; }
    }
    
}