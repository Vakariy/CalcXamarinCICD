using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Android.Views;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@android:style/Theme.DeviceDefault.NoActionBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private TextView calcText;
        private string[] numbers = new string[2];
        private string @operator;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           
            calcText = FindViewById<TextView>(Resource.Id.input);
            numbers[0] = "0";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Java.Interop.Export("ButtonClick")]
        public void ButtonClick(View view)
        {
            Button button = (Button)view;
            if ("0123456789.".Contains(button.Text)) AddButtonValues(button.Text);
            else if ("+-*/".Contains(button.Text)) AddOperator(button.Text);            
            else if ("=" == button.Text) Calculate();
            else Clear();
        }

        private void AddButtonValues(string buttonText)
        {       
            int index = @operator == null ? 0 : 1;
            if (buttonText == "." && numbers[index].Contains(".")) return;
            numbers[index] += buttonText;
            if ((numbers[0].StartsWith("0")) && (numbers[0].Length > 1 ) 
                && (numbers[0][1]!= '.'))
                numbers[0] = numbers[0].Substring(1); // remove 0 from the start of number input
            UpdateCalculatorText();
        }

        private void AddOperator(string buttonText)
        {
            if(numbers[1] != null)
            {
                Calculate(buttonText);
                return;
            }
            @operator = buttonText;
            UpdateCalculatorText();
        }

        private void Calculate(string newOperator = null)
        {
            double? result = null;
            double? first = numbers[0] == null ? null : (double?)double.Parse(numbers[0]);
            double? second = numbers[1] == null ? null : (double?)double.Parse(numbers[1]);
            switch (@operator)
            {
                case "+":
                    result = first + second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    break;
                case "-":
                    result = first - second;
                    break;
            }
            if(result != null)
            {
                numbers[0] = result.ToString().Trim();
                @operator = newOperator;
                numbers[1] = null;
                UpdateCalculatorText();
            }
        }
        private void Clear()
        {
            numbers[0] = "0";
            numbers[1] = null;
            @operator = null;
            UpdateCalculatorText();
        }
        private void UpdateCalculatorText()
        {
            calcText.Text = $"{numbers[0]}{@operator}{numbers[1]}";
        }
    }
}

