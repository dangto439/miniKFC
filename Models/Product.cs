namespace MiniKFCStore.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
