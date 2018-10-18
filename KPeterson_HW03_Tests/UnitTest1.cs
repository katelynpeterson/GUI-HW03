using System;
using System.Collections.ObjectModel;
using KPeterson_HW03;
using KPeterson_HW03.ViewModel;
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
            Projects TestProject1 = new Projects { ID = 2, Name = TEST_NAME_1 };

            Assert.AreEqual(2, TestProject1.ID);
            Assert.AreEqual(TEST_NAME_1, TestProject1.Name);

            Projects TestProject2 = new Projects { ID = 4, Name = TEST_NAME_2 };

            Assert.AreEqual(4, TestProject2.ID);
            Assert.AreEqual(TEST_NAME_2, TestProject2.Name);
        }

        //[TestMethod]
        //public void RangeSliderTest_WithinRange()
        //{
        //    ViewModel_MainWindow vm = new ViewModel_MainWindow();

        //    ProjectButton button = new ProjectButton { Name = TEST_NAME_1, BtnHeight = 90 };
        //    //true if in the range
        //    Assert.IsTrue(button.BtnHeight <= vm.MaxRange && button.BtnHeight >= vm.MinRange);

        //}

        //[TestMethod]
        //public void RangeSliderTest_BeyondRange()
        //{
        //    ViewModel_MainWindow vm = new ViewModel_MainWindow();

        //    ProjectButton button = new ProjectButton { Name = TEST_NAME_1, BtnHeight = 301 };
        //    //false if beyond max
        //    Assert.IsFalse(button.BtnHeight <= vm.MaxRange && button.BtnHeight >= vm.MinRange);
           
        //}

        //[TestMethod]
        //public void RangeSliderTest_BelowRange()
        //{
        //    ViewModel_MainWindow vm = new ViewModel_MainWindow();

        //    ProjectButton button = new ProjectButton { Name = TEST_NAME_1, BtnHeight = 79 };
        //    //false if below min
        //    Assert.IsFalse(button.BtnHeight <= vm.MaxRange && button.BtnHeight >= vm.MinRange);
        //}
    }
}
