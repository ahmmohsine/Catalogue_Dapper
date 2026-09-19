namespace Catalogue.Core.Services.Mappings;

using Catalogue.Core.Dtos.Product;
using Catalogue.Core.Entities;

public static class ProductMappingExtensions
{
    public static ReadOnlyProductDTO ToReadOnlyDto(this Product entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new ReadOnlyProductDTO
        {
            Id = entity.Id,
            Titre = entity.Titre,
            Description = entity.Description,
            Stock = entity.Stock,
            CategoryId = entity.CategoryId,
            CreatedAt = entity.CreatedAt

        };
    }

    public static IReadOnlyList<ReadOnlyProductDTO> ToReadOnlyDtoList(this IEnumerable<Product> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);

        return entities.Select(e => e.ToReadOnlyDto()).ToList().AsReadOnly();
    }

    public static Product ToEntity(this UpdateProductDTO entity, int id)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new Product
        {
            Id = id,
            Titre = entity.Titre,
            Description = entity.Description,
            Stock = entity.Stock,
            CategoryId = entity.CategoryId
        };
    }
    public static Product ToEntity(this CreateProductDTO entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return new Product
        {
            Titre = entity.Titre,
            Description = entity.Description,
            CreatedAt = DateTime.Now,
            Stock = entity.Stock,
            CategoryId = entity.CategoryId
        };
    }

    public static void UpdateFromDto(this Product entity, UpdateProductDTO dto)
    {
        ArgumentNullException.ThrowIfNull(entity);
        ArgumentNullException.ThrowIfNull(dto);

        entity.Titre = dto.Titre;
        entity.Description = dto.Description;
        entity.Stock = dto.Stock;
        entity.CategoryId = dto.CategoryId;

    }
}