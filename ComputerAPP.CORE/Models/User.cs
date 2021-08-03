using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    public class User
    {
        [Key]
        public int? UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}
