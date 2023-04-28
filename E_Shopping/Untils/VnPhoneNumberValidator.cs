using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Shopping.Untils
{
    public class VnPhoneNumberValidator
    {
        static Regex ValidVNPhoneNumberlRegex = CreateValidVNPhoneNumberRegex();

        private static Regex CreateValidVNPhoneNumberRegex()
        {
            string validphonenumberPattern = @"(84|0[3|5|7|8|9])+([0-9]{8})\b";

            return new Regex(validphonenumberPattern, RegexOptions.IgnoreCase);
        }

        public static bool VnPhoneNumberIsValid(string phonenumber)
        {
            bool isValid = ValidVNPhoneNumberlRegex.IsMatch(phonenumber);

            return isValid;
        }
    }
}
