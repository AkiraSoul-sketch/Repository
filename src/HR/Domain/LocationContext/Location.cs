using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Domain.LocationContext.ValueObjects;
using Domain.Shared;

namespace Domain.LocationContext
{
    public class Location
    {
        public Location(
            LocationId id,
            LocationName name,
            LocationAddress address,
            EntityLifeTime lifeTime,
            IanaTimeZone timeZone
        )
        {
            Id = id;
            Name = name;
            Address = address;
            LifeTime = lifeTime;
            TimeZone = timeZone;
        }

        public LocationId Id { get; }
        public LocationName Name { get; }
        public LocationAddress Address { get; }
        public EntityLifeTime LifeTime { get; set; }
        public IanaTimeZone TimeZone { get; set; }

        public void ChangeIanaTimeZone(IanaTimeZone newname)
        {
            if (!LifeTime.IsActive)
            {
                throw new InvalidOperationException("Объект удален");
            }

            TimeZone = newname;

            LifeTime = LifeTime.Update();
        }
    }
}
