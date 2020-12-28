using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee (){ Id = 1, Name = "Mizan", Department = Dept.HR, Email = "Mizan@mail.com"},
                new Employee (){ Id = 2, Name = "Min", Department = Dept.IT, Email = "Min@mail.com"},
               new Employee (){ Id = 3, Name = "Rahman", Department = Dept.Payroll, Email = "Rahman.Admin@mail.com"},

            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            var queryOne = from emp in _employeeList
                           select emp.Name + emp.Department + emp.Email;

            return _employeeList.FirstOrDefault(e =>e.Id == Id);

        }
    }
}
