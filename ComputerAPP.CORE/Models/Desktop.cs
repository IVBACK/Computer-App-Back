using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{  
    public class Desktop
    {
        [Key]
        public int? DesktopId { get; set; }

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
    }
}
