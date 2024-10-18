using System.Data;

namespace MiniKFCStore.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin, User
        public bool IsDeleted { get; set; } = false;
    }
}
