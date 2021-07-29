using System.ComponentModel.DataAnnotations;

namespace ComputerAPP.CORE.Models
{
    public class UserLoginRequest
    {
        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
