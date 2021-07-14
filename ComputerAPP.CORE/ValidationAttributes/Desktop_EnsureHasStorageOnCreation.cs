using ComputerAPP.CORE.Models;
using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.ValidationAttributes
{
    class Desktop_EnsureHasStorageOnCreation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var desktop = validationContext.ObjectInstance as Desktop;

            if (desktop.ValidateAllFieldsFull())
                return ValidationResult.Success;

            return new ValidationResult("Desktops Must Have a Ssd or Hdd");
        }
    }
}
