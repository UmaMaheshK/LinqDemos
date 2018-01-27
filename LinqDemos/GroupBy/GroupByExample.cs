using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos.GroupBy
{
    class GroupByExample
    {
        static void Main(string[] args)
        {
            Example3();
        }
        static void Example1()
        {
            //var result = Employee.GetAllEmployees().GroupBy(e => e.DeptId).ToList();

            IList<IGrouping<int, Employee>> resultGroupBy = Employee.GetAllEmployees().GroupBy(e => e.DeptId).ToList();
            foreach (IGrouping<int, Employee> item in resultGroupBy)
            {
                Console.WriteLine("GroupBy DepartmentId : {0}", item.Key);
                foreach (Employee emp in item)
                    Console.WriteLine("Id := {0,-2} Name : = {1,-10} Gender := {2,-6} DepartmentId := {3}", emp.Id, emp.Name, emp.Gender, emp.DeptId);
            }
            /*
                GroupBy DepartmentId : 102
                Id := 1  Name : = Rahul      Gender := Male   DepartmentId := 102
                Id := 3  Name : = Pooja      Gender := Female DepartmentId := 102
                Id := 8  Name : = Sachin     Gender := Male   DepartmentId := 102
                GroupBy DepartmentId : 101
                Id := 2  Name : = Vijay      Gender := Male   DepartmentId := 101
                Id := 5  Name : = Mary       Gender := Female DepartmentId := 101
                Id := 6  Name : = Mathew     Gender := Male   DepartmentId := 101
                GroupBy DepartmentId : 103
                Id := 4  Name : = Mithun     Gender := Male   DepartmentId := 103
                Id := 7  Name : = John       Gender := Male   DepartmentId := 103

             */
        }
        static void Example2()
        {
            //var result = Employee.GetAllEmployees().GroupBy(e => e.DeptId).ToList();

            IList<IGrouping<int, Employee>> resultGroupBy = (from emp in Employee.GetAllEmployees()
                                                             group emp by emp.DeptId).ToList();

            foreach (IGrouping<int, Employee> item in resultGroupBy)
            {
                Console.WriteLine("GroupBy DepartmentId : {0}", item.Key);
                foreach (Employee emp in item)
                    Console.WriteLine("Id := {0,-2} Name : = {1,-10} Gender := {2,-6} DepartmentId := {3}", emp.Id, emp.Name, emp.Gender, emp.DeptId);
            }
            /*
                GroupBy DepartmentId : 102
                Id := 1  Name : = Rahul      Gender := Male   DepartmentId := 102
                Id := 3  Name : = Pooja      Gender := Female DepartmentId := 102
                Id := 8  Name : = Sachin     Gender := Male   DepartmentId := 102
                GroupBy DepartmentId : 101
                Id := 2  Name : = Vijay      Gender := Male   DepartmentId := 101
                Id := 5  Name : = Mary       Gender := Female DepartmentId := 101
                Id := 6  Name : = Mathew     Gender := Male   DepartmentId := 101
                GroupBy DepartmentId : 103
                Id := 4  Name : = Mithun     Gender := Male   DepartmentId := 103
                Id := 7  Name : = John       Gender := Male   DepartmentId := 103

             */
        }
        static void Example3()
        {
            var groupByResult = Employee.GetAllEmployees().GroupBy(e => e.DeptId).ToList();
            foreach (var item in groupByResult)
            {
                Console.WriteLine();
                Console.WriteLine("DepartmentId := {0,-3} Employee Count := {1,-3}", item.Key, item.Count());
                Console.WriteLine("DepartmentId := {0,-3} Male Count := {1,-3}", item.Key, item.Count(m => m.Gender == "Male"));
                Console.WriteLine("DepartmentId := {0,-3} Female Count := {1,-3}", item.Key, item.Count(m => m.Gender == "Female"));
                Console.WriteLine("DepartmentId := {0,-3} Min Emp := {1,-3}", item.Key, item.Min(m => m.Id));
                Console.WriteLine("DepartmentId := {0,-3} Max Emp := {1,-3}", item.Key, item.Max(m => m.Id));
            }
            /*
                
                DepartmentId := 102 Employee Count := 3
                DepartmentId := 102 Male Count := 2
                DepartmentId := 102 Female Count := 1
                DepartmentId := 102 Min Emp := 1
                DepartmentId := 102 Max Emp := 8

                DepartmentId := 101 Employee Count := 3
                DepartmentId := 101 Male Count := 2
                DepartmentId := 101 Female Count := 1
                DepartmentId := 101 Min Emp := 2
                DepartmentId := 101 Max Emp := 6

                DepartmentId := 103 Employee Count := 2
                DepartmentId := 103 Male Count := 2
                DepartmentId := 103 Female Count := 0
                DepartmentId := 103 Min Emp := 4
                DepartmentId := 103 Max Emp := 7

             */
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public string Gender { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            Employee emp1 = new Employee { Id = 1, Name = "Rahul", Gender = "Male", DeptId = 102 };
            Employee emp2 = new Employee { Id = 2, Name = "Vijay", Gender = "Male", DeptId = 101 };
            Employee emp3 = new Employee { Id = 3, Name = "Pooja", Gender = "Female", DeptId = 102 };
            Employee emp4 = new Employee { Id = 4, Name = "Mithun", Gender = "Male", DeptId = 103 };
            Employee emp5 = new Employee { Id = 5, Name = "Mary", Gender = "Female", DeptId = 101 };
            Employee emp6 = new Employee { Id = 6, Name = "Mathew", Gender = "Male", DeptId = 101 };
            Employee emp7 = new Employee { Id = 7, Name = "John", Gender = "Male", DeptId = 103 };
            Employee emp8 = new Employee { Id = 8, Name = "Sachin", Gender = "Male", DeptId = 102 };

            List<Employee> empList = new List<Employee>();

            empList.Add(emp1);
            empList.Add(emp2);
            empList.Add(emp3);
            empList.Add(emp4);
            empList.Add(emp5);
            empList.Add(emp6);
            empList.Add(emp7);
            empList.Add(emp8);

            return empList;
        }
    }
}
