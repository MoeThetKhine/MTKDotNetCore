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
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var cmd = new SqlCommand(query, connection);

            if(sqlParameters is not null)
            {
                foreach(var sqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(sqlParameter.Name, sqlParameter.Value); 
                }
            }
            using var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            return dt;
        }

        #endregion

        #region Execute

        public int Execute(string query, params SqlParameterModel[]sqlParameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
            if (sqlParameters is not null)
            {
                foreach(var sqlParameter in sqlParameters)
                {
                    cmd.Parameters.AddWithValue(sqlParameter.Name, sqlParameter.Value);
                }
            }
            var result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

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
