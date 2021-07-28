using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ComputerAPP.SERVICE.Validations
{
    public class UserValidation
    {
        public bool IsEmailValid(string email)
        {
            EmailAddressAttribute e = new EmailAddressAttribute();
            if (e.IsValid(email))
                return true;
            else
                return false;
        }

        public bool IsNameValid(string name)
        {
            Regex regex = new Regex("^[A-Z][a-zA-Z]*$");

            if (regex.IsMatch(name))
                return true;
            else
                return false;          
        }
    }
}
