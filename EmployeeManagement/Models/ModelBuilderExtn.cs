using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtn
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = 1,
                  Name = "Mizanur",
                  Department = Dept.IT,
                  Email = "mizanur@email.com"
              },
              new Employee
              {
                  Id = 2,
                  Name = "Manur",
                  Department = Dept.IT,
                  Email = "manur@email.com"
              }
              );
        }
    }
}
