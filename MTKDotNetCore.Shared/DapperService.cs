﻿using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.Shared
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
            var lst = db.Query<T>(query,param).ToList();
            return lst;
        }

        #endregion

        #region Execute

        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;

        }

        #endregion

    }
}
