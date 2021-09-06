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

        [TestMethod()]
        public void GetQuantityForProductTest()
        {
            int extected = 114148;
            var actual = calc.GetQuantityForProduct(3, 1, 15, 20, 45);
            Assert.AreEqual(extected, actual);
        }

        [TestMethod()]
        public void GetMaterialTest1_0_003()
        {
            int type = 1;
            double expected = 0.003;
            var actual = calc.GetMaterial(type);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void GetMaterialTest2_0_00012()
        {
            int type = 2;
            double expected = 0.0012;
            var actual = calc.GetMaterial(type);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMaterialTest3_ArgumentException()
        {
            int type = 3;
            Assert.ThrowsException<ArgumentException>(() => calc.GetMaterial(type));
        }

        [TestMethod()]
        public void IsBadArgumentTest1_False()
        {
            int count = 1;
            float w = 0.2F;
            float h = 0.2F;

            bool expected = false;

            var actual = calc.IsBadArgument(count, w, h);

            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void IsBadArgumentTest2_True()
        {
            int count = -1;
            float w = 0.2F;
            float h = 0.2F;

            bool expected = true;

            var actual = calc.IsBadArgument(count, w, h);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void IsBadArgumentTest3_True()
        {
            int count = -1;
            float w = -0.2F;
            float h = 0.2F;

            bool expected = true;

            var actual = calc.IsBadArgument(count, w, h);

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void ItogIntTest_16()
        {
            double x = 15.0004;

            int expected = 16;

            var actual = calc.ItogInt(x);

            Assert.AreEqual(expected, actual);

        }


        [TestMethod()]
        public void ItogIntTest_15()
        {
            double x = 15.0000;

            int expected = 15;

            var actual = calc.ItogInt(x);

            Assert.AreEqual(expected, actual);

        }
    }
}