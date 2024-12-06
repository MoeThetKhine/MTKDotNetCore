using Dapper;

namespace MTKDotNetCore.ConsoleApp4.Dapper
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Query

        public List<T> Query<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<T>(query, param).ToList();
        }

        #endregion

        #region QueryFirstOrDefault

        public T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.QueryFirstOrDefault<T>(query, param)!;
        }

        #endregion

    }
}
