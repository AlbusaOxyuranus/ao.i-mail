using System;
using ao.i_mail.service.data.models;

namespace ao.i_mail.service.data.dal
{
    public interface IDataContext : IDisposable
    {
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class, IEntity;
        TEntity Get<TEntity, TGetType>(TGetType id) where TEntity : class;
    }
}