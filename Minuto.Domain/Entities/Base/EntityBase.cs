using System;

namespace Minuto.Domain.Entities.Base
{

    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { private get; set; }
    }
}
