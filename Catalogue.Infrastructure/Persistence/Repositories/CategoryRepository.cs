namespace Catalogue.Infrastructure.Persistence.Repositories;

using Catalogue.Core.Entities;
using Catalogue.Core.Interfeces;
using Catalogue.Infrastructure.Persistence;
using Dapper;

public class CategoryRepository : ICategoryRepository
{
    private readonly DbConnectionFactory _connectionFactory;

    public CategoryRepository(DbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<int> CreateCategoryAsync(Category category,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(category);

        const string sql = @"
            INSERT INTO category (titre, description, createdat) 
            VALUES (@Titre, @Description, @CreatedAt);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, category, cancellationToken: cancellationToken);

        return await connection.ExecuteScalarAsync<int>(command);
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        const string sql = @"
            SELECT 
                id AS Id, 
                createdat AS CreatedAt, 
                description AS Description, 
                titre AS Titre 
            FROM category;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, cancellationToken: cancellationToken);

        var result = await connection.QueryAsync<Category>(command);
        return result.ToList();
    }

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            SELECT 
                id AS Id, 
                createdat AS CreatedAt, 
                description AS Description, 
                titre AS Titre 
            FROM category 
            WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);

        return await connection.QueryFirstOrDefaultAsync<Category>(command);
    }

    public async Task<bool> UpdateCategoryAsync(Category category, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(category);

        const string sql = @"
            UPDATE category 
            SET titre = @Titre, 
                description = @Description 
            WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, category, cancellationToken: cancellationToken);

        int rowsAffected = await connection.ExecuteAsync(command);
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id, CancellationToken cancellationToken = default)
    {
        const string sql = "DELETE FROM category WHERE id = @Id;";

        using var connection = _connectionFactory.CreateConnection();
        var command = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);

        int rowsAffected = await connection.ExecuteAsync(command);
        return rowsAffected > 0;
    }

}