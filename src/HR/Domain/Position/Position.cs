using Domain.LocationContext.ValueObjects;
using Domain.Position.ValueObject;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position
{
    public class Position
    {
        public Position(PositionId id, NotEmptyName name, EntityLifeTime lifeTime, PositionDescription description)
        {
            Id = id;
            Name = name;
            LifeTime = lifeTime;
            Description = description;
        }
        public PositionId Id { get; }
        public NotEmptyName Name { get; }
        public EntityLifeTime LifeTime { get; }
        public PositionDescription Description { get; }
    }
}
