using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.MiniKpayDapperApi
{
    public class DapperService
    {
        private readonly string _connectionString;

        public DapperService(string conectionString)
        {
            _connectionString = conectionString;
        }
        #region Query

        public List<T> Query<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var lst = db.Query<T>(query, param).ToList();
            return lst;
        }

        #endregion

        #region QueryFirstOrDefault

        public T QueryFirstOrDefault<T>(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);

            var item = db.QueryFirstOrDefault<T>(query, param);
            return item;
        }

        #endregion
    }
}
