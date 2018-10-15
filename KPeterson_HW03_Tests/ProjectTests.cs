using System;
using KPeterson_HW03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPeterson_HW03_Tests
{
    [TestClass]
    public class ProjectTests
    {
        [TestMethod]
        public void ProjectNameCannotBeEmpty()
        {
            var project = new Projects();
            project.Name = null;
            Assert.AreEqual(project[nameof(project.Name)], "The project must have a name.");
        }

        [TestMethod]
        public void ProjectMustHaveStartDate()
        {
            var project = new Projects();
            //project.StartDate = "";
            Assert.AreEqual(project[nameof(project.StartDate)], "Project must have a start date.");
        }

        [TestMethod]
        public void ProjectCannotAddEmptyType()
        {
            var project = new Projects();
            project.Type = null;
            Assert.AreEqual(project[nameof(project.Type)], "You cannot add an empty type.");
        }
    }
}
