using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    public class Notebook
    {
        [Key]     
        public int? NoteBookId { get; set; }

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
    }
}
