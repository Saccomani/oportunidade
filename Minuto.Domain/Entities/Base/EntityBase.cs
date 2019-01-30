using System;
using System.Collections.Generic;

namespace Minuto.Domain.Entities.Base
{

    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = System.Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
