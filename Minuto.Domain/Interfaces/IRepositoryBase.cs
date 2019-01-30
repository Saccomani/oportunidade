using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minuto.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T: class, new()
    {
        //implements here whatever generic methods
    }
}
