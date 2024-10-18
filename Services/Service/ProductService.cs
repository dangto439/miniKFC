using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;
using MiniKFCStore.Services.Interface;

namespace MiniKFCStore.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync() => _productRepository.GetAllAsync();

        public Task<Product> GetProductByIdAsync(Guid id) => _productRepository.GetByIdAsync(id);

        public Task CreateProductAsync(Product product) => _productRepository.AddAsync(product);

        public Task UpdateProductAsync(Product product) => _productRepository.UpdateAsync(product);

        public Task DeleteProductAsync(Guid id) => _productRepository.SoftDeleteAsync(id);
    }
}
