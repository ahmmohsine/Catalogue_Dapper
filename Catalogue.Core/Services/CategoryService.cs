using Catalogue.Core.Dtos.Category;
using Catalogue.Core.Interfeces;
using Catalogue.Core.Services.Mappings;
namespace Catalogue.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryDTO createCategory, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateCategoryAsync(createCategory.ToEntity(), cancellationToken);
        }

        public async Task<bool> DeleteCategoryAsync(int id, CancellationToken token = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);
            return await _categoryRepository.DeleteCategoryAsync(id, token);
        }

        public async Task<IEnumerable<ReadOnlyCategoryDTO>?> GetAllAsync(CancellationToken token)
        {
            return (await _categoryRepository.GetAllAsync(token)).ToReadOnlyDtoList();
        }

        public async Task<ReadOnlyCategoryDTO?> GetByIdAsync(int id, CancellationToken token)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);
            return (await _categoryRepository.GetByIdAsync(id, token)).ToReadOnlyDto();
        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDTO dto, CancellationToken token)
        {
            if (id <= 0) return false;
            return await _categoryRepository.UpdateCategoryAsync(dto.ToEntity(id), token);
        }
    }
}
