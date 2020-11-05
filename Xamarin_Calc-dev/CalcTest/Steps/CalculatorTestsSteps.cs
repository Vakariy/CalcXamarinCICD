using CalcTest.Views;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CalcTest.Steps
{
    [Binding]
    public class CalculatorTestsSteps
    {
        CalcView calc;

        [Given(@"calculator app is initialized")]
        public void GivenCalculatorAppIsInitialized()
        {
            AppInit.StartApp();
            calc = new CalcView();
        }

        [When(@"The (.*) number typed at the calculator")]
        public void WhenTheNumberTypedAtTheCalculator(double operand)
        {
            string num = operand.ToString();
            char[] number = num.ToCharArray();
            foreach (var item in number)
            {
                calc.TapOnButton(item.ToString());
            }
        }

        [When(@"I tap on substract button")]
        public void WhenITapOnSubstractButton()
        {
            calc.TapOnMinus();
        }

        [Then(@"I see (.*) number and substract operand at the input field")]
        public void ThenISeeNumberAndSubstractOperandAtTheInputField(double operand)
        {
            Assert.AreEqual(operand + "-", calc.CalcViewText);
        }

        [Then(@"I see (.*) and (.*) numbers separated by substract operand")]
        public void ThenISeeAndNumbersSeparatedBySubstractOperand(double first, double second)
        {
            string expected = first + "-" + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [When(@"I tap on equal button")]
        public void WhenITapOnEqualButton()
        {
            calc.TapOnEqual();
        }

        [Then(@"I see the (.*) of operation at the input field")]
        public void ThenISeeTheOfOperationAtTheInputField(double result)
        {
            Assert.AreEqual(result.ToString(), calc.CalcViewText);
        }

        // DIVISION
        [When(@"I tap on division button")]
        public void WhenITapOnDivisionButton()
        {
            calc.TapOnDivide();
        }

        [Then(@"I see (.*) and (.*) numbers separated by division operand")]
        public void ThenISeeAndNumbersSeparatedByDivisionOperand(double first, double second)
        {
            string expected = first + "/" + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        // DIvision on "0"
        [Then(@"I see informational error message")]
        public void ThenISeeInformationalErrorMessage()
        {
            Assert.AreEqual("Wrong input!", calc.CalcViewText);
        }

        //Tap Comma after initialising
        [When(@"I tap on '(.*)' button")]
        public void WhenITapOnButton(string operation)
        {
            calc.TapOnButton(operation);
        }      

        [Then(@"I see (.*) and '(.*)' sign")]
        public void ThenISeeAndSign(int operand, string operation)
        {
            string expected = operand+operation;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        [Then(@"I see (.*) and (.*) numbers separated by '(.*)' sign")]
        public void ThenISeeAndNumbersSeparatedBySign(int first, int second, string operation)
        {
            string expected = first+ operation + second;
            Assert.AreEqual(expected, calc.CalcViewText);
        }

        //add positive tests
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(string operand)
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
        }

        [When(@"I select a sign like plus")]
        public void WhenISelectASignLikePlus()
        {
            calc.TapOnPlus();
        }

        [When(@"the second number is (.*)")]
        public void WhenTheSecondNumberIs(string operand)
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
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            Assert.AreEqual(expectedResult, calc.CalcViewText);
        }

        //multiply positive tests

        [When(@"I select a sign like multiply")]
        public void WhenISelectASignLikeMultiply()
        {
            calc.TapOnProduct();
        }
    }
}
