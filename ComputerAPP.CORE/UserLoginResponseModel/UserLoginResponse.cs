using System;

namespace ComputerAPP.CORE.Models
{
    [Serializable]
    public class UserLoginResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
