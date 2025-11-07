using Npgsql;
using Dapper;
using src.Domain.Models;
using src.Repository.Interface;
using src.Configs;
using Microsoft.Extensions.Options;

namespace src.Repository;

public class CoursesRepository(IOptions<PostgresConfig> config) : ICoursesRepository
{
    private readonly PostgresConfig _config = config.Value;

    public Task<Courses> Create(Courses course)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Courses> Get(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Courses>> List()
    {
        using var conn = new NpgsqlConnection(_config.Skillboostdb);
        var sql = "";
        List<Courses> result = [.. (await conn.QueryAsync<Courses>(sql))];
        return result;
    }

    public Task<Courses> Update(Courses course)
    {
        throw new NotImplementedException();
    }
}
