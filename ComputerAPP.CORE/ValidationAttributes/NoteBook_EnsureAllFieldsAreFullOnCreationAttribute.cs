using ComputerAPP.CORE.Models;
using System.ComponentModel.DataAnnotations;


namespace ComputerAPP.CORE.ValidationAttributes
{
    class NoteBook_EnsureAllFieldsAreFullOnCreationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var noteBook = validationContext.ObjectInstance as NoteBook;

            if (noteBook.ValidateAllFieldsFull())
                return ValidationResult.Success;

            return new ValidationResult("All Fields Must Be Full");
        }
    }
}
