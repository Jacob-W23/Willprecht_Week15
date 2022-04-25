using Microsoft.VisualStudio.TestTools.UnitTesting;
using Group2_CompRepair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Group2_CompRepair.Controllers;
using Group2_CompRepair.Models;

namespace Group2_CompRepair.Tests
{
    [TestClass()]
    public class UnitTests
    {
        [TestMethod()]
        public void AuthenticationFailTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("thisisthekey1234");

            User user = new User
            {
                username = "username12",
                password = "password123"
            };

            var ret = manager.Authentication(user.username, user.password);

            Assert.IsNull(ret);
        }

        [TestMethod()]
        public void AuthenticationSucceedTest()
        {
            JwtAuthenticationManager manager = new JwtAuthenticationManager("thisisthekey1234");

            User user = new User
            {
                username = "admin",
                password = "password"
            };

            var ret = manager.Authentication(user.username, user.password);

            Assert.IsNotNull(ret);
        }

        [TestMethod()]
        public void EmployeesTest()
        {
            EmployeesController employees = new EmployeesController();

            Assert.IsNotNull(employees.GetEmployees());
        }

        [TestMethod()]
        public void CustomersTest()
        {
            CustomersController customers = new CustomersController();

            Assert.IsInstanceOfType(customers.GetCustomers().Id, typeof(int));
        }

        [TestMethod()]
        public void SoftwareTest()
        {
            SoftwaresController software = new SoftwaresController();

            Software ware = new Software
            {
                SoftwareName = "TestWare",
                SoftwareDescription = "This is a test",
                LicensesInStock = 5,
                SoftwareType = "Test",
                SoftwarePrice = (decimal?)1000.0
            };

            Assert.IsTrue(ware.SoftwarePrice > 800);
        }
    }
}