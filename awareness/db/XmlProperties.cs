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

namespace awareness.db
{
    public class XmlProperties {
        XmlDocument xmlDoc;

        public string XmlString {
            get {
                StringBuilder sb = new StringBuilder();
                XmlWriter xml = XmlWriter.Create(sb);
                xmlDoc.WriteContentTo(xml);
                xml.Close();
                return sb.ToString();
            }
            set {
                xmlDoc = new XmlDocument();
                if (string.IsNullOrEmpty(value)){
                    xmlDoc.LoadXml(CreateNewPropertiesXml());
                } else {
                    xmlDoc.LoadXml(value);
                }
            }
        }

        public string CurrencySymbol {
            get { return xmlDoc.GetElementsByTagName("symbol")[0].InnerText; }
            set { xmlDoc.GetElementsByTagName("symbol")[0].InnerText = value; }
        }

        public bool PlaceCurrencySymbolAfterValue {
            get { return bool.Parse(xmlDoc.GetElementsByTagName("placeAfterValue")[0].InnerText); }
            set { xmlDoc.GetElementsByTagName("placeAfterValue")[0].InnerText = value.ToString(); }
        }

        public XmlProperties() {
            XmlString = null;
        }

        public XmlProperties(string xmlText){
            XmlString = xmlText;
        }

        private static string CreateNewPropertiesXml() {
            StringBuilder sb = new StringBuilder();
            XmlWriter xml = XmlWriter.Create(sb);

            xml.WriteStartDocument();
            xml.WriteStartElement("properties");
            xml.WriteStartElement("currency");

            xml.WriteStartElement("symbol");
            xml.WriteString("$");
            xml.WriteEndElement();

            xml.WriteStartElement("placeAfterValue");
            xml.WriteString("False");
            xml.WriteEndElement();

            xml.WriteEndElement();
            xml.WriteEndElement();

            xml.Close();
            return sb.ToString();
        }
    }
}
