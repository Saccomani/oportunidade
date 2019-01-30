using System;
using Minuto.Domain.Interfaces;

namespace Minuto.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity>
             where TEntity : class, new()
    {

        public RepositoryBase()
        {
      
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
