using System;
using System.Collections.Generic;
using System.Text;
using Domain.LocationContext.ValueObjects;

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
                throw new ArgumentNullException(
                    nameof(value),
                    "Идентификатор не может быть пустым."
                );

            return new PositionId(value);
        }
    }
}
