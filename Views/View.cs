
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using viewshospital.validators;

namespace viewshospital.views
{
    public class View : IView
    {
        private Validator validator = new Validator();
        private string name;

        public View(string name)
        {
            this.name = name;
        }

        public string Run(string passedData = "")
        {
            List<string> errorList;
            string inputLine;
            do
            {
                InputPrompt(passedData);
                inputLine = Console.ReadLine();
                errorList = validator.GetErrorList(GetFormats(inputLine));
                Console.Clear();
                OutputErrors(errorList);
                if (errorList.Count != 0 && name == "Tryagain")
                {
                    return "2";
                }

            } while (errorList.Count != 0 && TryAgain());


            return inputLine;
        }

        private bool TryAgain()
        {
            var view = new View("Tryagain");
            var choice = int.Parse(view.Run());

            switch (choice)
            {
                case 1:
                    return true;
                case 2:
                    return false;
            }
            return false;
        }

        private void InputPrompt(string passedData)
        {
            Console.WriteLine("------- " + name + " view -------");
            Console.Write(LoadXmlView());
            Console.Write(passedData);
            var inputFormat = GetFormatNames();
            Console.WriteLine("\nType " + inputFormat + ":");
        }

        private void OutputErrors(List<string> errorList)
        {
            foreach (var error in errorList)
            {
                Console.WriteLine(error);
            }
        }

        private string LoadXmlView()
        {
            var viewNode = FindViewNode();
            var builder = new StringBuilder();
            foreach (XmlNode lineNode in viewNode)
            {
                if (lineNode.Name == "line")
                {
                    builder.AppendLine(lineNode.InnerText);
                }
            }
            return builder.ToString();
        }

        private string GetFormatNames()
        {
            var viewNode = FindViewNode();
            return viewNode["input-format"].InnerText;
        }

        private List<string> GetFormats(string inputValues)
        {
            var formats = new List<string>();

            var viewNode = FindViewNode();
            var xmlElement = viewNode["input-format"];
            if (xmlElement == null) return formats;
            var formatNames = xmlElement.InnerText;

            var splittedFormatNames = formatNames.Split(' ');
            var splittedValues = inputValues.Split(' ');

            if (splittedValues.Length != splittedFormatNames.Length)
            {
                return null;
            }

            for (int i = 0; i < splittedFormatNames.Length; i++)
            {
                var format = splittedFormatNames[i]
                             + " " + GetFormatPattern(splittedFormatNames[i])
                             + " " + splittedValues[i];
                formats.Add(format);
            }

            return formats;
        }

        private string GetFormatPattern(string formatName)
        {
            var viewsDocument = new XmlDocument();
            viewsDocument.Load("views.xml");

            if (viewsDocument.DocumentElement == null) return "";
            var formatNodes = viewsDocument.DocumentElement.GetElementsByTagName("formats")[0];
            foreach (XmlNode node in formatNodes)
            {
                if (node.Attributes != null && node.Attributes["name"].InnerText == formatName)
                {
                    return node.InnerText;
                }
            }
            return "";
        }

        private XmlNode FindViewNode()
        {
            var viewsDocument = new XmlDocument();
            viewsDocument.Load("views.xml");

            var viewNodes = viewsDocument.DocumentElement.GetElementsByTagName("view");
            foreach (XmlNode node in viewNodes)
            {
                if (node.Attributes["name"].InnerText == name)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
