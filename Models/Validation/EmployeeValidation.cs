using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCQRSPatternTest.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ApiCQRSPatternTest.Models.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        private DataContext _dataContext;
        public EmployeeValidation(DataContext dataContext)
        {
            _dataContext = dataContext;
            
            RuleFor(m =>m.Empno).NotNull().NotEmpty().WithMessage("Employee not empty!");
            RuleFor(m => m.Empno).MustAsync(
                async (Empno,ct) => (
                    await _dataContext.Employee.AllAsync(m => m.Empno != Empno)
            )).WithMessage("Exit employee on database");

            RuleFor(m =>m.Firstname).NotNull().NotEmpty().WithMessage("Firstname not empty!");
            RuleFor(m =>m.Lastname).NotNull().NotEmpty().WithMessage("Lastname not empty!");
            RuleFor(m =>m.Position).NotNull().NotEmpty().WithMessage("Position not empty!");
            RuleFor(m => m.Salary).GreaterThan(0).WithMessage("Salary must greater than 0");
        }
    }
}