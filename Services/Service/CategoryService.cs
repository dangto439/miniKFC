using MiniKFCStore.Models;
using MiniKFCStore.Repositories.Interface;
using MiniKFCStore.Services.Interface;

namespace MiniKFCStore.Services.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync() => _categoryRepository.GetAllAsync();

        public Task<Category> GetCategoryByIdAsync(Guid id) => _categoryRepository.GetByIdAsync(id);

        public Task CreateCategoryAsync(Category category) => _categoryRepository.AddAsync(category);

        public Task UpdateCategoryAsync(Category category) => _categoryRepository.UpdateAsync(category);

        public Task DeleteCategoryAsync(Guid id) => _categoryRepository.SoftDeleteAsync(id);
    }
}
