using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository: IEmployeeRepository
    {
        private List<Employee> _employeeslist;
        
        public MockEmployeeRepository()
        {
            _employeeslist = new List<Employee>()
            {
                new Employee() { Id = 1,Name = "Aakash",Email = "aakashjoshi1386@gmail.com",Department = Dept.IT},
                new Employee() { Id = 2, Name = "Gautam", Email = "gautam@gmail.com", Department = Dept.Payroll},
                new Employee() { Id = 3,Name = "Niketa",Email = "Niketa@ymail.com",Department = Dept.HR}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeslist.Max(e => e.Id) + 1;  
            _employeeslist.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee =  _employeeslist.FirstOrDefault(e => e.Id == id);
            if (employee != null) {
                _employeeslist.Remove(employee);
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeslist;
        }

        public Employee GetEmployee(int Id)
        {
            return this._employeeslist.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeslist.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null) {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }

        public Employee GetByName(string name)
        {
            var result = new Employee();
            return result;
        }

    }
}
