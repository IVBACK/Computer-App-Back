using ComputerAPP.CORE.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    [Desktop_EnsureHasStorageOnCreation]
    public class Desktop
    {
        [Key]
        public int DesktopId { get; set; }

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
        public string Psu { get; set; }

        [Required]
        [StringLength(50)]
        public string Case { get; set; }

        public bool ValidateAllFieldsFull()
        {
            if (!string.IsNullOrWhiteSpace(Psu) &&
                !string.IsNullOrWhiteSpace(Cpu) &&
                !string.IsNullOrWhiteSpace(Gpu) &&
                !string.IsNullOrWhiteSpace(Ram) &&
                !string.IsNullOrWhiteSpace(Case))
            {
                return true;
            }
            return false;
        }
    }
}
