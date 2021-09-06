using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        Calculation calc = new Calculation();


        [TestMethod()]
        public void GetProdutcTest1_1_1()
        {
            int type = 1;
            double expected = 1.1;
            var actual = calc.GetProdutc(type);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod()]
        public void GetProdutcTest2_2_5()
        {
            int type = 2;
            double expected = 2.5;
            var actual = calc.GetProdutc(type);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetProdutcTest3_8_43()
        {
            int type = 3;
            double expected = 8.43;
            var actual = calc.GetProdutc(type);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetProdutcTest4_ArgumentException()
        {
            int type = 4;
            Assert.ThrowsException<ArgumentException>(() => calc.GetProdutc(type));
        }
            
    }
}