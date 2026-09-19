namespace Catalogue.Infrastructure.Persistence.Repositories;

using Catalogue.Core.Entities;
using Catalogue.Core.Interfeces;
using Catalogue.Infrastructure.Persistence;
using Dapper;

public class ProductRepository : IProductRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public ProductRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<int> CreateAsync(Product product, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(product);

        const string sql = @"
            INSERT INTO product (titre, description, stock, categoryId)
            VALUES (@Titre, @Description, @Stock, @CategoryId);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, product, cancellationToken: token);

        return await connection.ExecuteScalarAsync<int>(command);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken token = default)
    {
        const string sql = @"
            SELECT 
                id AS Id, 
                titre AS Titre, 
                description AS Description, 
                stock AS Stock, 
                categoryId AS CategoryId,
                createdAt as CreatedAt
            FROM product;";

        // 2. Ajout du 'using var' pour garantir le Dispose de la connexion
        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, cancellationToken: token);

        var result = await connection.QueryAsync<Product>(command);
        return result.ToList();
    }

    public async Task<Product?> GetByIdAsync(int id, CancellationToken token = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

        const string sql = @"
            SELECT 
                id AS Id, 
                titre AS Titre, 
                description AS Description, 
                stock AS Stock, 
                categoryId AS CategoryId,
                CreatedAt as CreatedAt
            FROM product 
            WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: token);

        return await connection.QueryFirstOrDefaultAsync<Product>(command);
    }

    public async Task<bool> UpdateAsync(Product product, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(product);

        const string sql = @"
            UPDATE product 
            SET titre = @Titre, 
                description = @Description,
                categoryId = @CategoryId,
                stock = @Stock
            WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, product, cancellationToken: token);

        int rowsAffected = await connection.ExecuteAsync(command);
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(id, 1);

        const string sql = "DELETE FROM product WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);

        int rowsAffected = await connection.ExecuteAsync(command);
        return rowsAffected > 0;
    }
}