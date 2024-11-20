namespace MTKDotNetCore.MiniKpay.Database;

public class DapperService
{
    private readonly string _connectionString;

    public DapperService(string connectionString)
    {
        _connectionString = connectionString;
    }

    #region QueryAsync

    public async Task<List<T>> QueryAsync<T>(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);

        var lst = (await db.QueryAsync<T>(query, param)).ToList();
        return lst;
    }

    #endregion

    #region QueryFirstOrDefaultAsync

    public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);

        var item = await db.QueryFirstOrDefaultAsync<T>(query, param);
        return item;
    }

    #endregion

    #region ExecuteAsync

    public async Task<int> ExecuteAsync(string query, object? param = null)
    {
        using IDbConnection db = new SqlConnection(_connectionString);

        var result = await db.ExecuteAsync(query, param);
        return result;
    }

    #endregion

}
