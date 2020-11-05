using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcTest.Views;
using NUnit.Framework;

namespace CalcTest
{
    public class TestCalculator
    {
        CalcView calc = new CalcView();
        [SetUp]
        public void BeforeEveryTestOpenApplication()
        {
            AppInit.StartApp();
        }
        [Test]
        public void Test()
        {
            CalcView.Repl();
        }
        [TestCase("2", "+", "3", "5", Description = "Check addition")]
        public void CheckAddition(string first, string oper, string second, string expected)
        {
            calc.TapOnButton(first);
            Assert.AreEqual(first, calc.CalcViewText);
            calc.TapOnButton(oper);
            Assert.AreEqual(first + oper, calc.CalcViewText);
            calc.TapOnButton(second);
            Assert.AreEqual(first + oper + second, calc.CalcViewText);
            calc.TapOnEqual();
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [TestCase("0", "0")]
        [TestCase("12", "2")]
        [TestCase("9", "1.5")]
        [TestCase("2", "0.333333333333333")]
        public void DivisionTests(string operand, string result)
        {
            if (operand.Length > 1)
            {
                char[] number = operand.ToCharArray();
                foreach (var item in number)
                {
                    calc.TapOnButton(item.ToString());
                }
            }
            else calc.TapOnButton(operand);
            calc.TapOnButton("/").TapOnSix().TapOnEqual();
            Assert.AreEqual(result, calc.CalcViewText);
        }

        [TestCase("+", "8")]
        [TestCase("-", "4")]
        [TestCase("*", "12")]
        [TestCase("/", "3")]
        public void MainFunctionsTests(string sign, string result)
        {
            calc.TapOnSix().TapOnButton(sign).TapOnTwo().TapOnEqual();
            Assert.AreEqual(result, calc.CalcViewText);
        }

        [TestCase("0")]
        [TestCase("existing")]
        public void MultiplyOnZero(string operand)
        {
            if (operand == "0") calc.TapOnButton(operand);
            calc.TapOnButton("*").TapOnNine().TapOnSeven().TapOnEqual();
            Assert.AreEqual("0", calc.CalcViewText);
        }

        [Test(Description = "Checking reaction on zero division")]
        public void DivisionOnZero()
        {
            calc.TapOnFour().TapOnThree().TapOnButton("0")
                .TapOnButton("/").TapOnButton("0").TapOnEqual();
            Assert.AreEqual("Wrong input!", calc.CalcViewText);
        }

        [TestCase(2, "9.99999998E+17")]
        [TestCase(3, "9.99999997E+26")]
        [TestCase(4, "9.99999996E+35")]
        [TestCase(5, "9.99999995E+44")]
        [TestCase(6, "9.99999994E+53")]
        [TestCase(10, "9.9999999E+89")]
        public void WorkWithBigNumbers(int count, string result)
        {
            for (int i = 0; i < count; i++)
            {
                calc.TapOnNine().TapOnNine().TapOnNine().
                    TapOnNine().TapOnNine().TapOnNine()
                    .TapOnNine().TapOnNine().TapOnNine();
                if (i != (count - 1)) calc.TapOnButton("*");
            }
            calc.TapOnEqual();
            Assert.AreEqual(result, calc.CalcViewText);
        }
    }
}
