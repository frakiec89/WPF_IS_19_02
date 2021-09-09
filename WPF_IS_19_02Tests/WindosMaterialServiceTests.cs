using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF_IS_19_02.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_IS_19_02.View.Tests
{
    [TestClass()]
    public class WindosMaterialServiceTests
    {
        [TestMethod()]
        public void intMinTest_2_15()
        {
            int list = 2;

            int expected = 15;

            var actual = WindosMaterialService.IntMin(list);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CountContentTest_15_31_15()
        {
            int list = 15;
            int Count = 31;
            int expected = 15;
            var actual = WindosMaterialService.CountContent(list , Count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CountContentTest_30_31_1()
        {
            int list = 30;
            int Count = 31;
            int expected = 1;
            var actual = WindosMaterialService.CountContent(list, Count);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void CountContentTest_0_14_14()
        {
            int list = 0;
            int Count = 14;
            int expected = 14;
            var actual = WindosMaterialService.CountContent(list, Count);
            Assert.AreEqual(expected, actual);
        }
    }
}