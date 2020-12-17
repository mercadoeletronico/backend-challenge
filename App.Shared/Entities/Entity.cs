using System;

namespace App.Shared.Entities
{
    public class Entity
    {

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}
