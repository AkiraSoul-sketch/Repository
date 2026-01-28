using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Position.ValueObject
{
    public class PositionDescription
    {
        public string Value { get; }

        private PositionDescription(string value)
        {
            Value = value;
        }
        public static PositionDescription Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Значение было пустым.", nameof(value));

            if (value.Length > 500)
                throw new ArgumentException("Строка привышает длину символов.", nameof(value));

            return new PositionDescription(value);
        }
    }
}
