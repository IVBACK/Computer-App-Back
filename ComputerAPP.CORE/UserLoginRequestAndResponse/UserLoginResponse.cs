using System;

namespace ComputerAPP.CORE.Models
{
    [Serializable]
    public class UserLoginResponse
    {
        public string UserId { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
    }
}
