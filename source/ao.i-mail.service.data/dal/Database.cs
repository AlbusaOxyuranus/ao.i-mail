using System.Data.SqlClient;

namespace ao.i_mail.service.data.dal
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
            _connectionString = "Data Source=WINSTATION;Integrated Security=True"; //connectionString;
        }

        public bool ExistDatabase(string databaseName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command =
                    new SqlCommand(string.Format("select COUNT(*) from master.dbo.sysdatabases where ('['+name+']'= '{0}' or name='{0}')", databaseName), connection);
                var isExist = command.ExecuteScalar();
                connection.Close();
                return (int)isExist == 1;

            }
        }

        public void CreateDatabase(string databaseName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"create database [{databaseName}]", connection);
                var insertedId = command.ExecuteScalar();
                connection.Close();
            }
        }

        public void DeleteDatabase(string databaseName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand($"drop database [{databaseName}]", connection);
                var insertedId = command.ExecuteScalar();
                connection.Close();
            }
        }
    }
}