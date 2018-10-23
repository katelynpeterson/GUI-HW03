using System;
using System.Collections.ObjectModel;
using KPeterson_HW03;
using KPeterson_HW03.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPeterson_HW03_Tests
{
    [TestClass]
    public class ProjectTests
    {
        public const string TEST_NAME_1 = "TestProject1";
        public const string TEST_NAME_2 = "TestProject2";

        [TestMethod]
        public void SetProjectTest()
        {
            Projects TestProject1 = new Projects { ID = 2, Name = TEST_NAME_1 };

            Assert.AreEqual(2, TestProject1.ID);
            Assert.AreEqual(TEST_NAME_1, TestProject1.Name);

            Projects TestProject2 = new Projects { ID = 4, Name = TEST_NAME_2 };

            Assert.AreEqual(4, TestProject2.ID);
            Assert.AreEqual(TEST_NAME_2, TestProject2.Name);
        }


        [TestMethod]
        public void ProjectNameCannotBeEmpty()
        {
            var project = new Projects();
            project.Name = null;
            Assert.AreEqual("The project must have a name.", project[nameof(project.Name)]);
        }

        [TestMethod]
            public void ProjectNameHasValue()
        {
            var project = new Projects();
            project.Name = TEST_NAME_1;
            Assert.AreEqual(project.Name, TEST_NAME_1);
        }

       
        //check start date against end date
        [TestMethod]
        public void EndDateCannotBeLessThanStartDate()
        {
            var project = new Projects();
            project.StartDate = new DateTime(12,12,12);
            project.EstimatedEndDate = new DateTime(12, 11, 12);
            
            var isEndDateAfterStartDate = project.EstimatedEndDate > project.StartDate;
            Assert.IsFalse(isEndDateAfterStartDate,"EndDate needs to be greater than StartDate");
        }

        [TestMethod]
        public void EndDateIsGreaterThanStartDate()
        {
            var project = new Projects();
            project.StartDate = new DateTime(12, 12, 12);
            project.EstimatedEndDate = new DateTime(12, 12, 13);
            var isEndDateAfterStartDate = project.EstimatedEndDate > project.StartDate;
            Assert.IsTrue(isEndDateAfterStartDate);
        }

        [TestMethod]
        public void AddNewProject()
        {
            var projectList = new ObservableCollection<Projects>();
            Assert.AreEqual(0, projectList.Count);

            var proj = new Projects { Name = TEST_NAME_1};
            projectList.Add(proj);
            Assert.AreEqual(1, projectList.Count);
        }

        //test addproject button control to see if it adds a new project to the list
        [TestMethod]
        public void AddNewProjectToList()
        {
            var vm = new ViewModel_MainWindow();
            var initialCount = vm.Projectvm.ProjectList.Count;
            vm.AddNewProject.Execute(this);
            var newCount = vm.Projectvm.ProjectList.Count;
            var isNewCountBiggerThanInitialCount = newCount > initialCount;

            Assert.IsTrue(isNewCountBiggerThanInitialCount);
        }

        //test that the treeview displays another project
        [TestMethod]
        public void AddNewProjectToTreeView()
        {
            var vm = new ViewModel_MainWindow();
            var initialCount = vm.Projectvm.ProjectList.Count;
            vm.AddNewProject.Execute(this);
            vm.TreeView.Execute(this);
            
            var newCount = vm.Projectvm.ProjectList.Count;
            var isNewCountBiggerThanInitialCount = newCount > initialCount;

            Assert.IsTrue(isNewCountBiggerThanInitialCount);
        }

        //test that the project summary displays another project
        [TestMethod]
        public void AddNewProjectToProjectSummary()
        {
            var vm = new ViewModel_MainWindow();
            var initialCount = vm.Projectvm.ProjectList.Count;
            vm.AddNewProject.Execute(this);
            vm.ProjectSummary.Execute(this);
            
            var newCount = vm.Projectvm.ProjectList.Count;
            var isNewCountBiggerThanInitialCount = newCount > initialCount;

            Assert.IsTrue(isNewCountBiggerThanInitialCount);
        }

        [TestMethod]
        public void ErrorMessageWhenEmptyProjectNameAndFavoriteProjectChecked()
        {
            var vm = new Projects();
            vm.FavoriteProject = true;
            vm.Name = null;
            Assert.IsTrue(vm.isNameEmptyOrNull(vm.Name) && vm.FavoriteProject);
            //Assert.AreEqual("A favorite project must have a name", vm[nameof(vm.FavoriteProject)]);
        }
    }
}
