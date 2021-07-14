using ComputerAPP.CORE.Models;
using System.ComponentModel.DataAnnotations;


namespace ComputerAPP.CORE.ValidationAttributes
{
    class NoteBook_EnsureHasStorageOnCreation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var noteBook = validationContext.ObjectInstance as NoteBook;

            if (noteBook.CheckStorage())
                return ValidationResult.Success;

            return new ValidationResult("Desktops Must Have a Ssd or Hdd");
        }
    }
}
