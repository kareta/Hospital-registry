using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace viewshospital.validators
{
    public class Validator
    {
        //format-name pattern value
        public List<string> GetErrorList(List<string> formats)
        {
            var errorList = new List<string>();

            if (formats == null)
            {
                errorList.Add("Data is typed in a wrong format");
                return errorList;
            }

            foreach (var format in formats)
            {
                var splittedFormat = format.Split(' ');

                if (splittedFormat.Length != 3)
                {
                    continue;
                }

                var formatName = splittedFormat[0];
                var pattern = splittedFormat[1];
                var value = splittedFormat[2];

                if (!Regex.IsMatch(value, pattern))
                {
                    errorList.Add(formatName + " is incorrect");
                }
            }
            return errorList;
        }
    }
}
