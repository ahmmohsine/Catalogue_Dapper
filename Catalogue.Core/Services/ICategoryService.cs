using Catalogue.Core.Dtos.Category;

namespace Catalogue.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<ReadOnlyCategoryDTO>?> GetAllAsync(CancellationToken token);
        Task<bool> DeleteCategoryAsync(int id, CancellationToken token = default);
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategory, CancellationToken token);
        Task<ReadOnlyCategoryDTO?> GetByIdAsync(int id, CancellationToken token);
        Task<int> CreateCategoryAsync(CreateCategoryDTO createCategory, CancellationToken cancellationToken);
    }
}
