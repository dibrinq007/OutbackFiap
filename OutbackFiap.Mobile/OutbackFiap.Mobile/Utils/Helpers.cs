using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace OutbackFiap.Mobile.Utils
{
    public static class Helpers
    {
        public static bool IsAValidEmail(string emailaddress)
        {
            try
            {
                return Regex.IsMatch(emailaddress,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
