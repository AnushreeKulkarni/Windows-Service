using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceAssignment.BusinessLayer;

namespace WindowsServiceAssignment.DataAccessLayer
{
   public class LinqMethods
    {
        DataAccess access = new DataAccess();
        List<Employee> empList;


        public List<Employee> BasicFilter(List<Employee> empList)
        {
            //empList = access.GetDetailsFromDatabase();
            var empListFiltered = (from emp in empList
                                   where Convert.ToInt32(emp.EmployeeID) < 1500
                                   select emp).ToList();
            return empListFiltered;
        }
        public List<Employee> OrderBy(List<Employee> empList)
        {
            //empList = access.GetDetailsFromDatabase();
            var empListOrdered = (from emp in empList
                                   orderby emp.EmployeeID descending
                                   select new Employee {EmployeeID=emp.EmployeeID,EmployeeName=emp.EmployeeName}).ToList();
            return empListOrdered;
        }

        public List<Employee> Join(List<Employee> empList)
        {
           
            //empList = access.GetDetailsFromDatabase();

            var empListJoin1 = (from emp in empList
                                where Convert.ToInt32(emp.EmployeeID) > 1500
                                select new {emp.EmployeeID,emp.EmployeeName }).ToList();
            var empListJoin2 = (from emp in empList
                                where Convert.ToInt32(emp.EmployeeID) > 1500
                                select new { emp.EmployeeID,emp.EmployeeEmail}).ToList();
            var empListJoined = (from emp in empListJoin1
                                 join empl in empListJoin2
                                 on emp.EmployeeID equals empl.EmployeeID
                                 select new Employee{EmployeeID= emp.EmployeeID,EmployeeName= emp.EmployeeName,EmployeeEmail= empl.EmployeeEmail }).ToList();

            return empListJoined;
            
                }

        
    public List<Employee> GroupBy(List<Employee> empList)
    {
            //empList = access.GetDetailsFromDatabase();
            List<Employee> emplist = new List<Employee>();
            var empListGrouped = (from emp in empList
                                 group emp by emp.EmployeeID
                                 into newgroup
                                 select newgroup).ToList();
            foreach(var group in empListGrouped)
            {
                foreach (var e in group)
                {              
                    emplist.Add(e);      
                }
            }
            return emplist;
        }
    }
}


