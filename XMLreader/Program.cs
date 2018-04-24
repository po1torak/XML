using System.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XMLreader
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version='1.0' standalone='no'?>
                            <root>
                                <person id='1'>
                                    <name>Alan</name>
                                    <url>http://www.google.com</url>
                                </person>
                                <person id='2'>
                                    <name>Louis</name>
                                    <url>http://www.yahoo.com</url>
                                </person>
                            </root>";

            XmlTextReader reader = new XmlTextReader("task.xml");

            while(reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: 
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: 
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: 
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

            Console.WriteLine();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string json = JsonConvert.SerializeXmlNode(doc);

            Console.WriteLine(json);

            Console.ReadLine();
        }
    }
}
