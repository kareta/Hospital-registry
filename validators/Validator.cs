using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace validators
{
    public class Validator
    {
        public const string RangePattern = @"range\([-+]?[0-9]*[.,]?[0-9]+ [-+]?[0-9]*[.,]?[0-9]+\)";
        public const string MultiwordPattern = @"MULTIWORD";
        //format-name pattern value
        public List<string> GetErrorList(List<InputFormat> formats)
        {
            var errorList = new List<string>();

            if (formats == null)
            {
                errorList.Add("Data is typed in a wrong format");
                return errorList;
            }

            foreach (var format in formats)
            {
                var formatIsCorrect = IsRange(format.Pattern) && RangeIsCorrect(format)
                    || IsMultiword(format.Pattern) || ValueDoesMatch(format);

                if (!formatIsCorrect)
                {
                    errorList.Add(format.Name + " is incorrect");
                }
            }    
            return errorList;
        }

        public bool IsMultiword(string pattern)
        {
            return Regex.IsMatch(pattern, MultiwordPattern);
        }

        public bool MultiwordIsCorrect(InputFormat format)
        {
            return Regex.IsMatch(format.Value, ".+");
        }

        public bool IsRange(string pattern)
        {
            return Regex.IsMatch(pattern, RangePattern);
        }

        public bool RangeIsCorrect(InputFormat format)
        {
            var regex = new Regex("[-+]?[0-9]*[.,]?[0-9]+");
            var match = regex.Match(format.Pattern);

            var lowerLimit = double.Parse(match.Groups[0].ToString(), CultureInfo.InvariantCulture);
            match = match.NextMatch();
            var upperLimit = double.Parse(match.Groups[0].ToString(), CultureInfo.InvariantCulture);

            double value;
            if (!double.TryParse(format.Value, out value))
            {
                return false;
            }

            return lowerLimit < value && value < upperLimit;
        }

        public bool ValueDoesMatch(InputFormat format)
        {
            return Regex.IsMatch(format.Value, format.Pattern);
        }
    }

    
}


