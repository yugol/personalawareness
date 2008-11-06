/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 26/10/2008
 * Time: 20:46
 *
 */
using System;

namespace awareness
{
    /// <summary>
    /// Description of Calculator.
    /// </summary>
    public class Calculator {
        public const int MAX_DIGIT_LENGTH = 15;

        private double previousValue;
        private char operation;
        private double currentValue;

        private string valueString;
        private bool newValue;

        public Calculator(){
            clearEverything();
        }

        public string ValueString
        {
            get { return valueString; }
        }

        public void WriteChar(char ch){
            if ('0' <= ch&&ch <= '9'){
                if (newValue){
                    valueString = "" + ch;
                    newValue = false;
                } else if (valueString == "0")   {
                    valueString = "" + ch;
                } else if (valueString == "-0")   {
                    valueString = "-" + ch;
                } else if (digitCount() < MAX_DIGIT_LENGTH)  {
                    valueString += ch;
                }
            } else if (ch == '.')   {
                if (newValue){
                    valueString = "0.";
                    newValue = false;
                }
                if (!isDecimal()){
                    valueString += ch;
                }
            } else if (ch == '~')   {
                if (valueString[0] == '-'){
                    valueString = valueString.Substring(1);
                } else {
                    valueString = '-' + valueString;
                }
                newValue = false;
            } else if (ch == '+'||ch == '-'||ch == '*'||ch == '/')  {
                if (!newValue){
                    operate();
                }
                operation = ch;
            } else if (ch == 'C')   {
                clearEverything();
            } else if (ch == '=')   {
                operate();
            }
        }

        void clearEverything(){
            valueString = "0";
            previousValue = double.NaN;
            operation = '\0';
            currentValue = 0;
            newValue = true;
        }

        int digitCount(){
            int digitCount = 0;
            for (int i = 0; i < valueString.Length; ++i){
                if (char.IsDigit(valueString[i])){
                    ++digitCount;
                }
            }
            return digitCount;
        }

        bool isDecimal(){
            return valueString.Contains(".");
        }

        void operate(){
            currentValue = double.Parse(valueString);
            switch (operation){
            case '\0':
                previousValue = currentValue;
                break;
            case '+':
                previousValue += currentValue;
                break;
            case '-':
                previousValue -= currentValue;
                break;
            case '*':
                previousValue *= currentValue;
                break;
            case '/':
                previousValue /= currentValue;
                break;
            }
            operation = '\0';
            valueString = previousValue.ToString();
            newValue = true;
        }
    }
}
