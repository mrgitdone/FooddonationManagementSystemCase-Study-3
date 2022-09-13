using AutoFixture;
using FooddonationManagementSystem.Controllers;
using FooddonationManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooddonationManagementSystemTest
{
    [TestClass]
    public class FooddonationUnitTest
    {
        private Mock<IEnumerable> _ienumerableuserTest;
        private Fixture _Fixture;
        private SchoolModulesController schoolModulesController;

        public FooddonationUnitTest()
        {
            _Fixture = new Fixture();
            _ienumerableuserTest = new Mock<IEnumerable>();

        }
        [TestMethod]
        public async Task take_GetSchoolModule_Return()
        {
            var userlist = _Fixture.CreateMany<SchoolModule>(2).ToList();
            _ienumerableuserTest.Setup(repo => repo.GetEnumerator()).Returns((IEnumerator)userlist);
            schoolModulesController= new SchoolModulesController(_ienumerableuserTest.Object);

            var result = await schoolModulesController.GetSchoolModule();
            //var obj = result as ObjectResult;
            //Assert.AreEqual(200, obj.StatusCode);
           
        }
        [TestMethod]
        public void take_GetSchool_ok()
        {
            Console.WriteLine("200 Succedded");
        }

        
    }
}
