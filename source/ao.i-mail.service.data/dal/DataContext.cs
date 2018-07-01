using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ao.i_account.service.dal;
using ao.i_mail.service.data.models;

namespace ao.i_mail.service.data.dal
{
    public class DataContext : IDataContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TEntity Insert<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
           var usp = Mapper.InsertOperation(entity);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(usp.NameUsp, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in usp.Parameters) command.Parameters.Add(new SqlParameter(parameter.Key,parameter.Value));

                var insertedId = command.ExecuteScalar();

                if (insertedId == null)
                {
                    command.CommandText = usp.NameUsp;
                    insertedId = command.ExecuteScalar();
                }

                var id = int.Parse(insertedId.ToString());
                entity.Id=id;
                connection.Close();
                return entity;
            }
        }

        public TEntity Get<TEntity, TGetType>(TGetType id) where TEntity : class 
        {
            var usp = Mapper.GetOperation<TEntity, TGetType>(id);
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(usp.NameUsp, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                foreach (var parameter in usp.Parameters)
                    command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));

                var getObject = command.ExecuteScalar();

                if (getObject == null)
                {
                    command.CommandText = usp.NameUsp;
                    getObject = command.ExecuteScalar();
                }

                var result = Serializer.DeserializeDataContract<List<TEntity>>(getObject.ToString());
                connection.Close();
                return result[0];
            }
        }

        #region implementation IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}