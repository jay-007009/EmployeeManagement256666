using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationClasses
{
    public class JoiningDateValidation
    {
        public bool IsJoiningDateValid(string joiningDate)
        {
        
            Regex regex = new Regex(@"[0-9]{4}/[0-9]{2}/[0-9]{2}");
            Match match = regex.Match(joiningDate);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
