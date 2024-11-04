using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCQRSPatternTest.Models.ModelConfiguration
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            
            builder.HasKey(m => m.Empno); //set primary key
            builder.Property(m => m.Empno).ValueGeneratedNever(); //diable auto increment
            builder.Property(m => m.Hiredate).HasDefaultValueSql("getdate()"); //map to server time

            builder.Property(m => m.Firstname).HasColumnType("nvarchar(100)");
            builder.Property(m => m.Lastname).HasColumnType("nvarchar(100)");
            builder.Property(m => m.Position).HasColumnType("nvarchar(200)");
        }
    }
}