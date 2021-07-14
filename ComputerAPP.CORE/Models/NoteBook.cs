using ComputerAPP.CORE.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    [NoteBook_EnsureHasStorageOnCreation]
    public class NoteBook
    {
        [Key]     
        public int NoteBookId { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(50)]
        public string Cpu { get; set; }

        [Required]
        [StringLength(50)]
        public string Gpu { get; set; }

        [Required]
        [StringLength(50)]
        public string Ram { get; set; }
        
        [StringLength(50)]
        public string SsdCap { get; set; }

        [StringLength(50)]
        public string HddCap { get; set; }

        [Required]
        [StringLength(50)]
        public string Battery { get; set; }

        public bool CheckStorage()
        {
            if(string.IsNullOrWhiteSpace(SsdCap))
            {
                if(string.IsNullOrWhiteSpace(HddCap))
                    return false;
                return true;
            }
            else if(string.IsNullOrWhiteSpace(HddCap))
            {
                if (string.IsNullOrWhiteSpace(SsdCap))
                    return false;
                return true;
            }
            return true;
        }
    }
}
