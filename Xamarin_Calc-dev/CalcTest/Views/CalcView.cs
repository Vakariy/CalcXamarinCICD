using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace CalcTest.Views
{
    public class CalcView
    {
        public static IApp App => AppInit.App;
        public Query textView = x => x.Id("input");
        public Query btnDel = x => x.Marked("DEL");

        public Query btnZero = x => x.Marked("0");
        public Query btnOne = x => x.Marked("1");
        public Query btnTwo = x => x.Marked("2");
        public Query btnThree = x => x.Marked("3");
        public Query btnFour = x => x.Marked("4");
        public Query btnFive = x => x.Marked("5");
        public Query btnSix = x => x.Marked("6");
        public Query btnSeven = x => x.Marked("7");
        public Query btnEight = x => x.Marked("8");
        public Query btnNine = x => x.Marked("9");
        public Query btnComma = x => x.Marked(".");

        public Query btnPlus = x => x.Marked("+");
        public Query btnProduct = x => x.Marked("*");
        public Query btnDivide = x => x.Marked("/");
        public Query btnMinus = x => x.Marked("-");
        public Query btnEqual = x => x.Marked("=");
        public static void Repl()
        {
            App.Repl();
        }
        public CalcView TapOnOne()
        {
            App.Tap(btnOne);
            return this;
        }
        public CalcView TapOnTwo()
        {
            App.Tap(btnTwo);
            return this;
        }
        public CalcView TapOnThree()
        {
            App.Tap(btnThree);
            return this;
        }
        public CalcView TapOnFour()
        {
            App.Tap(btnFour);
            return this;
        }
        public CalcView TapOnFive()
        {
            App.Tap(btnFive);
            return this;
        }
        public CalcView TapOnSix()
        {
            App.Tap(btnSix);
            return this;
        }
        public CalcView TapOnSeven()
        {
            App.Tap(btnSeven);
            return this;
        }
        public CalcView TapOnEight()
        {
            App.Tap(btnEight);
            return this;
        }
        public CalcView TapOnNine()
        {
            App.Tap(btnNine);
            return this;
        }
        public CalcView TapOnComma()
        {
            App.Tap(btnComma);
            return this;
        }
        public CalcView TapOnEqual()
        {
            App.Tap(btnEqual);
            return this;
        }
        public CalcView TapOnPlus()
        {
            App.Tap(btnPlus);
            return this;
        }
        public CalcView TapOnMinus()
        {
            App.Tap(btnMinus);
            return this;
        }
        public CalcView TapOnProduct()
        {
            App.Tap(btnProduct);
            return this;
        }
        public CalcView TapOnDivide()
        {
            App.Tap(btnDivide);
            return this;
        }
        public string GetResult()
        {
            return App.Query(textView)[0].Text.Trim();
        }
        public string CalcViewText
        {
            get
            {
                return App.Query(textView)[0].Text.Trim();
            }
        }

        public CalcView TapOnButton(string symbol)
        {
            switch (symbol)
            {
                case "1":
                    App.Tap(btnOne);
                    return this;
                case "2":
                    App.Tap(btnTwo);
                    return this;
                case "3":
                    App.Tap(btnThree);
                    return this;
                case "4":
                    App.Tap(btnFour);
                    return this;
                case "5":
                    App.Tap(btnFive);
                    return this;
                case "6":
                    App.Tap(btnSix);
                    return this;
                case "7":
                    App.Tap(btnSeven);
                    return this;
                case "8":
                    App.Tap(btnEight);
                    return this;
                case "9":
                    App.Tap(btnNine);
                    return this;
                case "0":
                    App.Tap(btnZero);
                    return this;
                case "+":
                    App.Tap(btnPlus);
                    return this;
                case "-":
                    App.Tap(btnMinus);
                    return this;
                case "*":
                    App.Tap(btnProduct);
                    return this;
                case "/":
                    App.Tap(btnDivide);
                    return this;
                case ".":
                    App.Tap(btnComma);
                    return this;
                default:
                    return this;
            }
        }
    }
}
