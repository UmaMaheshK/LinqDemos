using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
    }

    class InnerJoin
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
        {
            new Employee() { EmployeeId = 100, FullName = "Uma Mahesh1", DepartmentId = 11 },
            new Employee() { EmployeeId = 101, FullName = "Uma Mahesh2", DepartmentId = 12 },
            new Employee() { EmployeeId = 102, FullName = "Uma Mahesh3", DepartmentId = 13 },
        };

            List<Department> departments = new List<Department>
        {
            new Department() { DepartmentName = "Department1", DepartmentId = 11 },
            new Department() { DepartmentName = "Department2", DepartmentId = 12 },
            new Department() { DepartmentName = "Department3", DepartmentId = 13 },
        };
            //Inner join with Linq query execution
            //deffered execution
            var result = from emp in employees
                         join dept in departments on emp.DepartmentId equals dept.DepartmentId
                         select new { emp.FullName, dept.DepartmentName };
            Console.WriteLine("Using Linq Query");
            //Immediate execution
            foreach (var item in result)
                Console.WriteLine("Employee : {0} \t Department : {1}", item.FullName, item.DepartmentName);
            //deffered execution
            var result1 = employees.Join(departments, e => e.DepartmentId, d => d.DepartmentId, (e, d) => new { e.FullName, d.DepartmentName });
            Console.WriteLine("Using Linq Lamdba");
            //Immediate execution
            foreach (var item in result1)
                Console.WriteLine("Employee : {0} \t Department : {1}", item.FullName, item.DepartmentName);
        }
    }
}
