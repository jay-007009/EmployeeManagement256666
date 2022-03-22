using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationClasses
{
    public class PhoneNumberValidation
    {

        public bool IsPhoneNumberValid(string phoneNumber)
        {

            Regex regex = new Regex(@"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$");
            Match match = regex.Match(phoneNumber);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
