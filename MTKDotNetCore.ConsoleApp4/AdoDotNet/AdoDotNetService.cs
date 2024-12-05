using System.Data;

namespace MTKDotNetCore.ConsoleApp4.AdoDotNet
{
    public class AdoDotNetService
    {
        private readonly string _connectionString;

        public AdoDotNetService(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region DataTable Query

        public DataTable Query(string query, params SqlParameterModel[] sqlParameters)

        #endregion

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
}
