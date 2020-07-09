using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace WindowsServiceAssignment.BusinessLayer
{
   public class LinqMethods
    {
        //DataAccess access = new DataAccess();
        //List<Employee> empList;


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
                                   select emp).ToList();
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
        public bool LQuantifiersAny(List<Employee> empList)
        {
          
            if (empList.Any(emp => Convert.ToInt32(emp.EmployeeID) == 222222 || emp.EmployeeName.EndsWith("6")))
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        public bool LQuantifiersAll(List<Employee> empList)
        {
            if (empList.All(emp => Convert.ToInt32(emp.EmployeeID) == 1999 || emp.EmployeeName.StartsWith("N")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LQuantifiersContain(List<Employee> empList)
        {
            Employee e = new Employee() { EmployeeID = "12345", EmployeeName = "Anushree", EmployeeEmail = "123@gmail.com" };

            if (empList.Contains(e))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public double AggregateAvg(List<Employee> empList)
        {
            var avgID = (int)empList.Average(emp => Convert.ToInt32(emp.EmployeeID));
            return avgID;
        }
        public int AggregateMin(List<Employee> empList)
        {
            var minID = (int)empList.Min(emp => Convert.ToInt32(emp.EmployeeID));
            return minID;
        }
        public int AggregateMax(List<Employee> empList)
        {
            var maxID = (int)empList.Max(emp => Convert.ToInt32(emp.EmployeeID));
            return maxID;
        }
        public int AggregateCount(List<Employee> empList)
        {
            var idMaxCount = (int)empList.Count((emp => Convert.ToInt32(emp.EmployeeID) >=1700));
            return idMaxCount;
        }
        public int AggregateSum(List<Employee> empList)
        {
            var idSum = (int)empList.Sum(emp => Convert.ToInt32(emp.EmployeeID));
            return idSum;
        }
        public string ElementAt(List<Employee> empList)
        {
            var elementAt = (empList.ElementAt(17).EmployeeID+" "+empList.ElementAt(17).EmployeeName+" "+empList.ElementAt(17).EmployeeEmail);
          
            return elementAt;
            
        }
        public string ElementAtorDefault(List<Employee> empList)
        {
            var elementAtorDefault = (empList.ElementAtOrDefault(0).EmployeeID + " " + empList.ElementAtOrDefault(0).EmployeeName + " " + empList.ElementAtOrDefault(0).EmployeeEmail);
            return elementAtorDefault;
        }
        public string First(List<Employee> empList)
        {
            var first = empList.First(emp => Convert.ToInt32(emp.EmployeeID) > 1500).EmployeeID; 
            return first;

        }
        public Employee FirstOrDefault(List<Employee> empList)
        {
            var firstorDefault = empList.FirstOrDefault();
            return firstorDefault;
        }
        //public string Single(List<Employee> empList)
        //{
        //    var single = empList.Single(emp => emp.EmployeeName.Contains("Name999"));

        //    return single.ToString();
        //}
        public string Last(List<Employee> empList)
        {
            var last = empList.Last(emp => Convert.ToInt32(emp.EmployeeID) < 1600).EmployeeID;
            return last;
        }
        public List<Employee> Distinct(List<Employee> empList)
        {      
            var distinct = (from emp in empList.Distinct()
                           select emp).ToList();
            return distinct;
        }
        public List<Employee> Except(List<Employee> empList)
        {
            var empListExcept1 = (from emp in empList
                                  where Convert.ToInt32(emp.EmployeeID) > 1500
                                  select emp).ToList();
            var empListExcept2 = (from emp in empList
                                  where Convert.ToInt32(emp.EmployeeID) > 1600
                                  select emp).ToList();

            var except = (from emp in empListExcept1.Except(empListExcept2)
                         select emp).ToList();
            return except;
        }
        public List<Employee> Intersect (List<Employee> empList)
        {
            var empListIntersect1 = (from emp in empList
                                     where Convert.ToInt32(emp.EmployeeID) > 1500
                                     select emp).ToList();
            var empListIntersect2 = (from emp in empList
                                     where Convert.ToInt32(emp.EmployeeID) > 1600
                                     select emp).ToList();
            var intersect = (from emp in empListIntersect1.Intersect(empListIntersect2)
                             select emp).ToList();

            return intersect;

        }
        public List<Employee> Union(List<Employee> empList)
        {
            var empListUnion1 = (from emp in empList
                                 where Convert.ToInt32(emp.EmployeeID) >= 1500
                                 select emp).ToList();
            var empListUnion2 = (from emp in empList
                                 where Convert.ToInt32(emp.EmployeeID) < 1500
                                 select emp).ToList();
            var union = (from emp in empListUnion1.Union(empListUnion2)
                         select emp).ToList();
            return union;

        }
                    
        }
    }



