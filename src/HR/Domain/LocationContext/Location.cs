using Domain.LocationContext.ValueObjects;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Domain.LocationContext
{
    public class Location
    {
        public Location(LocationId id, NotEmptyName name, LocationAddress address, EntityLifeTime lifeTime, IanaTimeZone timeZone)
        {
            Id = id;
            Name = name;
            Address = address;
            LifeTime = lifeTime;
            TimeZone = timeZone;
        }
        public LocationId Id { get; }
        public NotEmptyName Name { get; }
        public LocationAddress Address { get; }
        public EntityLifeTime LifeTime { get; }
        public IanaTimeZone TimeZone { get; }
    }
}
