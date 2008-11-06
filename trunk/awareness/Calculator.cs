/*
 * Copyright (c) 2008 Iulian GORIAC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

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
