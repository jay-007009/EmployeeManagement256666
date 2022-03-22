using System;
using System.Text.RegularExpressions;

namespace ValidationClasses
{
    public class EmailValidation
    {
        public bool IsEmailIdValid(string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
