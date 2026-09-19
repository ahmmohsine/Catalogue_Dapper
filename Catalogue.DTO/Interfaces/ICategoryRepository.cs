using Catalogue.Core.Entities;

namespace Catalogue.Core.Interfeces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken token = default);
        Task<Category> GetByIdAsync(int id, CancellationToken token = default);
        Task<int> CreateCategoryAsync(Category category, CancellationToken token = default);
        Task<bool> UpdateCategoryAsync(Category category, CancellationToken token = default);
        Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default);
    }
}
