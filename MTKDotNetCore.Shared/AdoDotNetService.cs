using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

       
    }

    #region SqlParameterModel

    public class SqlParameterModel
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public SqlParameterModel() { }
        public SqlParameterModel(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
    #endregion
}
