namespace MiniKFCStore.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
