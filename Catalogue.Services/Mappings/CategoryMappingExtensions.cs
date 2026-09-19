namespace Catalogue.Service.Mappings;

using Catalogue.DTO.Category;
using Catalogue.Models;

public static class CategoryMappingExtensions
{
    public static ReadOnlyCategoryDTO ToReadOnlyDto(this Category entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new ReadOnlyCategoryDTO
        {
            Id = entity.Id,
            Titre = entity.Titre,
            Description = entity.Description
        };
    }

    public static IReadOnlyList<ReadOnlyCategoryDTO> ToReadOnlyDtoList(this IEnumerable<Category> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToReadOnlyDto()).ToList().AsReadOnly();
    }

    public static Category ToEntity(this CreateCategoryDTO dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return new Category
        {
            Titre = dto.Titre,
            Description = dto.Description
        };
    }

    public static void UpdateFromDto(this Category entity, UpdateCategoryDTO dto)
    {
        ArgumentNullException.ThrowIfNull(entity);
        ArgumentNullException.ThrowIfNull(dto);

        entity.Titre = dto.Titre;
        entity.Description = dto.Description;
    }
}