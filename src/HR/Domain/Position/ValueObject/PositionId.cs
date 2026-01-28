using Domain.LocationContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position.ValueObject
{
    public class PositionId
    {
        Guid Value { get; }

        private PositionId(Guid value)
        {
            Value = value;
        }

        public static PositionId Create(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentNullException("Идентификатор не может быть пустым.", nameof(value));

            return new PositionId(value);
        }
    }
}
