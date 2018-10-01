using System;
using System.Collections.ObjectModel;
using KPeterson_HW03;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KPeterson_HW03_Tests
{
    [TestClass]
    public class UnitTest1
    {
        public const string TEST_NAME_1 = "TestProject1";
        public const string TEST_NAME_2 = "TestProject2";

        [TestMethod]
        public void SetProjectTest()
        {
            ViewModel_Project project = new ViewModel_Project();

           ObservableCollection<Projects> _projectList = new ObservableCollection<Projects>();

            Projects TestProject1 = new Projects(2, TEST_NAME_1);

            Assert.AreEqual(2, TestProject1.ID);
            Assert.AreEqual(TEST_NAME_1, TestProject1.Name);

            Projects TestProject2 = new Projects(4, TEST_NAME_2);

            Assert.AreEqual(4, TestProject2.ID);
            Assert.AreEqual(TEST_NAME_2, TestProject2.Name);
        }
    }
}
