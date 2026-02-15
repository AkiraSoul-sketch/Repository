using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Departments.ValueObject
{
    public record Depth
    {
        public short Value { get; }

        private Depth(short value)
        {
            this.Value = value;
        }

        public static Depth Create(short value)
        {
            if (value < 1)
            {
                throw new ArgumentException("Глубина не может быть отрицательной.", nameof(value));
            }

            return new Depth(value);
        }
    }
}
