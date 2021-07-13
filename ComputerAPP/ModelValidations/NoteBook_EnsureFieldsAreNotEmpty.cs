using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerAPP.ModelValidations
{
    public class NoteBook_EnsureFieldsAreNotEmpty : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var noteBook = validationContext.ObjectInstance as NoteBook;

            if(noteBook != null && 
                !string.IsNullOrWhiteSpace(noteBook.Brand) &&
                !string.IsNullOrWhiteSpace(noteBook.Model) && 
                !string.IsNullOrWhiteSpace(noteBook.Cpu) &&
                !string.IsNullOrWhiteSpace(noteBook.Gpu))
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("All Fields Must Be Full");
        }
    }
}
