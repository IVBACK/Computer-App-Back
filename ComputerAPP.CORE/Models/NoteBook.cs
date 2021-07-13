using ComputerAPP.CORE.ValidationAttributes;
using System.ComponentModel.DataAnnotations;


namespace ComputerAPP.CORE.Models
{
    [NoteBook_EnsureAllFieldsAreFullOnCreationAttribute]
    public class NoteBook
    {
        public int? NoteBookId { get; set; }

        [Required]
        [StringLength(10)]
        public string Brand { get; set; }

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [StringLength(30)]
        public string Cpu { get; set; }

        [Required]
        [StringLength(30)]
        public string Gpu { get; set; }

        [Required]
        [StringLength(30)]
        public string Ram { get; set; }

        [Required]
        [StringLength(10)]
        public string Battery { get; set; }

        public bool ValidateAllFieldsFull()
        {
            if(NoteBookId.HasValue && 
                !string.IsNullOrWhiteSpace(Model) &&
                !string.IsNullOrWhiteSpace(Cpu) &&
                !string.IsNullOrWhiteSpace(Gpu) &&
                !string.IsNullOrWhiteSpace(Ram) &&
                !string.IsNullOrWhiteSpace(Battery))
            {
                return true;
            }
            return false;          
        }
    }
}
