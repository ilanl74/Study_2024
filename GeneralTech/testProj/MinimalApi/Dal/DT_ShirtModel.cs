using SQLitePCL;
using Microsoft.Data.Sqlite;
namespace Dal;

public class DT_ShirtModel
{
    private readonly string _connectionString;

    public DT_ShirtModel(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task Add(List<(string ExternalId, int Size, string Model, string Brand)> input)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            var sql = @"insert into ShirtModel(ExternalId,Size,Model,Brand)
                select $ExternalId,$Size,$Model,$Brand
                where not exists (select 1 from ShirtModel where ExternalId = $ExternalId);
                
            ";
            await conn.OpenAsync();
            foreach (var s in input)
            {
                SqliteCommand c = new(sql, conn);
                c.Parameters.AddWithValue("$ExternalId", s.ExternalId);
                c.Parameters.AddWithValue("$Size", s.Size);
                c.Parameters.AddWithValue("$Model", s.Model);
                c.Parameters.AddWithValue("$Brand", s.Brand);
                await c.ExecuteNonQueryAsync();
            }
        }

    }
}
