using Dapper; // https://www.youtube.com/watch?v=IVsN0WlufWc

using InstaPay.Api.Domain.Interfaces;
using InstaPay.Api.Domain.Models;

using Microsoft.Data.SqlClient;

namespace InstaPay.Api.Infrastructure.Data;

public class SqlServerRepository : IRepository<SepaBlob>
{
    private readonly string _connectionString;

    public SqlServerRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
    }

    public async Task<SepaBlob?> GetByIdAsync(string transactionId)
    {
        if (string.IsNullOrWhiteSpace(transactionId))
        {
            throw new ArgumentException("Transaction ID cannot be null or empty", nameof(transactionId));
        }

        const string query = @"
            SELECT TransactionId, MessageContent AS Content, CreatedDate AS CreatedTimestamp
            FROM SepaMessages 
            WHERE TransactionId = @TransactionId";

        await using var connection = new SqlConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<SepaBlob>(query, new { TransactionId = transactionId });
    }

    public async Task SaveAsync(SepaBlob message)
    {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "Message cannot be null");
            }

            const string query = @"
                INSERT INTO SepaMessages (TransactionId, MessageContent, CreatedDate)
                VALUES (@TransactionId, @Content, @CreatedTimestamp)";

            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(query, message);
    }
}