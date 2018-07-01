using System;
using ao.i_account.service.bal;
using ao.i_account.service.dal;
using ao.i_mail.service.data.dal;
using ao.i_mail.service.data.models;

namespace ao.i_mail.service.data.bal
{
    public sealed class BusinessContext : IBusinessContext
    {
        public BusinessContext(IMode mode)
        {
            var connectionString = mode.ConnectionString;
            DataContext = new DataContext(connectionString);
            Database = new Database(connectionString);
        }

        private IDataContext DataContext { get; }

        #region implementation IDisposable

        private readonly bool _disposed = false;


        public void Dispose()
        {
            Dispose(true);
            // ReSharper disable once GCSuppressFinalizeForTypeWithoutDestructor
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
                return;

            DataContext?.Dispose();
        }

        #endregion

        public TEntity Add<TEntity>(TEntity entity) where TEntity: class, IEntity
        {
           return DataContext.Insert(entity);
        }

        public TEntity Get<TEntity,TGetType>(TGetType id) where TEntity : class 
        {
            return DataContext.Get<TEntity, TGetType>(id);
        }

        public void Update<TEntity>()
        {
            throw new NotImplementedException();
        }

        public void Delete<TEntity>()
        {
            throw new NotImplementedException();
        }

        public Database Database { get; }
    }
}