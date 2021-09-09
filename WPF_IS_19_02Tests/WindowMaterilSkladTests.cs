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
    public class WindowMaterilSkladTests 
    {
        [TestMethod()]
        public void GetCountButtonTest_30_2()
        {
            int count = 30;
            int expected = 2;

            var actual = WindosMaterialService.GetCountButton(count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCountButtonTest_31_3()
        {
            int count = 31;
            int expected = 3;
            var actual = WindosMaterialService.GetCountButton(count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCountButtonTest_5_1()
        {
            int count = 5;
            int expected = 1;
            var actual = WindosMaterialService.GetCountButton(count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCountButtonTest_60_4()
        {
            int count = 60;
            int expected = 4;
            var actual = WindosMaterialService.GetCountButton(count);
            Assert.AreEqual(expected, actual);
        }
    }
}