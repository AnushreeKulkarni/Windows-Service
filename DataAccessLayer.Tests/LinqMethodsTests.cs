using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsServiceAssignment.BusinessLayer;
namespace BusinessLayer.Tests
{
   
    [TestClass]
    public class LinqMethodsTests
    {
       
        [TestMethod]
        public void Test_BasicFilter()
        {
            List<Employee> emplist = new List<Employee>();

            List<Employee> empl = new List<Employee>();


            emplist.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Expected result list

            empl.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Arrange

            List<Employee> expected = empl;
          
            //Act
            LinqMethods methods = new LinqMethods();
            List<Employee> actual = methods.BasicFilter(emplist);

            //Assert

            Assert.AreEqual(expected.Count, actual.Count);

            Assert.AreEqual(expected[0].EmployeeID, actual[0].EmployeeID);
            Assert.AreEqual(expected[0].EmployeeName, actual[0].EmployeeName);
            Assert.AreEqual(expected[0].EmployeeEmail, actual[0].EmployeeEmail);

            Assert.AreEqual(expected[1].EmployeeID, actual[1].EmployeeID);
            Assert.AreEqual(expected[1].EmployeeName, actual[1].EmployeeName);
            Assert.AreEqual(expected[1].EmployeeEmail, actual[1].EmployeeEmail);

            Assert.AreEqual(expected[2].EmployeeID, actual[2].EmployeeID);
            Assert.AreEqual(expected[2].EmployeeName, actual[2].EmployeeName);
            Assert.AreEqual(expected[2].EmployeeEmail, actual[2].EmployeeEmail);

        }
        [TestMethod]
        public void Test_OrderBy()
        {
            List<Employee> emplist = new List<Employee>();
            List<Employee> empl = new List<Employee>();

            emplist.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Expected result list
            empl.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            empl.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Arrange
            List<Employee> expected = empl;

            //Act
            LinqMethods methods = new LinqMethods();
            List<Employee> actual = methods.OrderBy(emplist);

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);

            Assert.AreEqual(expected[0].EmployeeID, actual[0].EmployeeID);
            Assert.AreEqual(expected[0].EmployeeName, actual[0].EmployeeName);
            Assert.AreEqual(expected[0].EmployeeEmail, actual[0].EmployeeEmail);

            Assert.AreEqual(expected[1].EmployeeID, actual[1].EmployeeID);
            Assert.AreEqual(expected[1].EmployeeName, actual[1].EmployeeName);
            Assert.AreEqual(expected[1].EmployeeEmail, actual[1].EmployeeEmail);

            Assert.AreEqual(expected[2].EmployeeID, actual[2].EmployeeID);
            Assert.AreEqual(expected[2].EmployeeName, actual[2].EmployeeName);
            Assert.AreEqual(expected[2].EmployeeEmail, actual[2].EmployeeEmail);

            Assert.AreEqual(expected[3].EmployeeID, actual[3].EmployeeID);
            Assert.AreEqual(expected[3].EmployeeName, actual[3].EmployeeName);
            Assert.AreEqual(expected[3].EmployeeEmail, actual[3].EmployeeEmail);

            Assert.AreEqual(expected[4].EmployeeID, actual[4].EmployeeID);
            Assert.AreEqual(expected[4].EmployeeName, actual[4].EmployeeName);
            Assert.AreEqual(expected[4].EmployeeEmail, actual[4].EmployeeEmail);

            Assert.AreEqual(expected[5].EmployeeID, actual[5].EmployeeID);
            Assert.AreEqual(expected[5].EmployeeName, actual[5].EmployeeName);
            Assert.AreEqual(expected[5].EmployeeEmail, actual[5].EmployeeEmail);

           

            CollectionAssert.AreEqual(expected.Select(emp => emp.EmployeeID).ToList(), actual.Select(emp => emp.EmployeeID).ToList());
            CollectionAssert.AreEqual(expected.Select(emp => emp.EmployeeName).ToList(), actual.Select(emp => emp.EmployeeName).ToList());
            CollectionAssert.AreEqual(expected.Select(emp => emp.EmployeeEmail).ToList(), actual.Select(emp => emp.EmployeeEmail).ToList());
        }
        [TestMethod]
        public void Test_Join()
        {
            List<Employee> emplist = new List<Employee>();
        
            List<Employee> result = new List<Employee>();

            emplist.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //result list
            
            result.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Arrange
            List<Employee> expected = result;

            //Act
            LinqMethods methods = new LinqMethods();
            List<Employee> actual = methods.Join(emplist);

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
        }
        [TestMethod]
        public void Test_GroupBy()
        {
            List<Employee> emplist = new List<Employee>();

            List<Employee> result = new List<Employee>();

            emplist.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            emplist.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //result list
            result.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1200", EmployeeName = "Name1200", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1400", EmployeeName = "Name1400", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1500", EmployeeName = "Name1500", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "1700", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });
            result.Add(new Employee { EmployeeID = "2000", EmployeeName = "Anushree", EmployeeEmail = "Anushree.Kulkarni@cognizant.com" });

            //Arrange
            List<Employee> expected = result;

            //Act
            LinqMethods methods = new LinqMethods();
            List<Employee> actual = methods.GroupBy(emplist);

            //Assert
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
