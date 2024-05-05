using Dapper;
using System.Data.SQLite;

namespace Project.Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<T>(SQLiteConnection connection)
{
    protected readonly SQLiteConnection _connection = connection;

    protected virtual async Task<IEnumerable<T>> GetAllAsync(string query)
    {
        try
        {
            await _connection.OpenAsync();
            return await _connection.QueryAsync<T>(query);
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    protected virtual async Task<T?> GetAsync(string query)
    {
        try
        {
            await _connection.OpenAsync();
            return await _connection.QueryFirstOrDefaultAsync<T>(query);
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    protected virtual async Task<int> AddAsync(string query, T param)
    {
        try
        {
            await _connection.OpenAsync();
            return await _connection.ExecuteAsync(query, param);
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}