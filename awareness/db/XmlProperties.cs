/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 27/11/2008
 * Time: 22:02
 *
 *
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


using System;
using System.Text;
using System.Xml;

namespace Awareness.db
{
    public class XmlProperties
    {
        private static readonly string CURRENCY_SYMBOL_TAG = "symbol";
        private static readonly string PLACE_AFTER_VALUE_TAG = "placeAfterValue";
        private static readonly string LAST_MEAL_REPORT_REASON_TAG = "lastMealReportReason";


        public string XmlString
        {
            get {
                return BuildPropertiesXml();
            }
            set {
                XmlDocument xmlDoc = new XmlDocument();
                if (string.IsNullOrEmpty(value)) {
                    xmlDoc.LoadXml(BuildPropertiesXml());
                } else {
                    xmlDoc.LoadXml(value);
                }

                try {
                    currencySymbol = xmlDoc.GetElementsByTagName(CURRENCY_SYMBOL_TAG)[0].InnerText;
                } catch (Exception) {
                }
                try {
                    placeCurrencySymbolAfterValue = bool.Parse(xmlDoc.GetElementsByTagName(PLACE_AFTER_VALUE_TAG)[0].InnerText);
                } catch (Exception) {
                }
                try {
                    lastMealReportReason = int.Parse(xmlDoc.GetElementsByTagName(LAST_MEAL_REPORT_REASON_TAG)[0].InnerText);
                } catch (Exception) {
                }
            }
        }

        private string currencySymbol = "$";
        public string CurrencySymbol
        {
            get {
                return currencySymbol;
            }
            set {
                currencySymbol = value;
            }
        }

        private bool placeCurrencySymbolAfterValue = false;
        public bool PlaceCurrencySymbolAfterValue
        {
            get {
                return placeCurrencySymbolAfterValue;
            }
            set {
                placeCurrencySymbolAfterValue = value;
            }
        }

        private int lastMealReportReason = 0 ;
        public int LastMealReportReason
        {
            get {
                return lastMealReportReason;
            }
            set {
                lastMealReportReason = value;
            }
        }

        public XmlProperties()
        {
            XmlString = null;
        }

        public XmlProperties(string xmlText)
        {
            XmlString = xmlText;
        }

        private string BuildPropertiesXml()
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter xml = XmlWriter.Create(sb);

            xml.WriteStartDocument();

            xml.WriteStartElement("properties");


            xml.WriteStartElement("currency");

            xml.WriteStartElement(CURRENCY_SYMBOL_TAG);
            xml.WriteString(currencySymbol);
            xml.WriteEndElement();

            xml.WriteStartElement(PLACE_AFTER_VALUE_TAG);
            xml.WriteString(placeCurrencySymbolAfterValue.ToString());
            xml.WriteEndElement();

            xml.WriteEndElement();


            xml.WriteStartElement(LAST_MEAL_REPORT_REASON_TAG);
            xml.WriteString(lastMealReportReason.ToString());
            xml.WriteEndElement();


            xml.WriteEndElement();

            xml.Close();
            return sb.ToString();
        }
    }
}
