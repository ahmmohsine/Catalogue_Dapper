using Catalogue.DTO.Category;
using Catalogue.Models;
using Catalogue.Repository;
namespace Catalogue.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }
        public int CreateCategory(UpdateCategoryDTO categoryDto)
        {
            return _categoryRepository.CreateCategory(MapUpdateCategoryDTOToCategory(categoryDto));
        }

        private Category MapUpdateCategoryDTOToCategory(UpdateCategoryDTO categoryDto)
        {
            return new Category()
            {
                Titre = categoryDto.Titre,
                Description = categoryDto.Description,
                CreatedAt = categoryDto.CreatedAt
            };
        }

        private static ReadOnlyCategoryDTO mapCatgoryToReadOnlyCategoryDTO(Category c)
        {
            return new()
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                Description = c.Description,
                Titre = c.Titre
            };
        }

        public ReadOnlyCategoryDTO GetById(int id)
        {
            return mapCatgoryToReadOnlyCategoryDTO(_categoryRepository.GetById(id));
        }

        public int UpdateCategory(UpdateCategoryDTO categoryDto)
        {
            return _categoryRepository.UpdateCategory(mapCatgoryToUpdateOnlyCategory(categoryDto));
        }

        private async Category mapCatgoryToUpdateOnlyCategory(UpdateCategoryDTO categoryDto)
        {
            return await new Task<Category>()
            {
                Titre = categoryDto.Titre,
                Description = categoryDto.Description,
                CreatedAt = categoryDto.CreatedAt
            };
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }


        public Task<bool> DeleteCategoryAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(UpdateCategoryDTO updateCategory, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCategoryDTO?> GetByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateCategoryAsync(CreateCategoryDTO createCategory, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<ReadOnlyCategoryDTO>?> ICategoryService.GetAllAsync(CancellationToken token)
        {
            var categories = await _categoryRepository.GetAllAsync(token);

            return await categories
                .Select(c => mapCatgoryToUpdateOnlyCategory)
                .ToList();
        }

        public Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDTO updateCategory, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
