using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Shared
{
    public class NotEmptyName
    {
        public const int MaxLength = 128;
        public const int MinLength = 3;

        public string Value { get; }

        private NotEmptyName(string value)
        {
            Value = value;
        }

        public static NotEmptyName Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException("Название локации не может быть пустым", nameof(value));

            if (value.Length > MaxLength)
                throw new ArgumentOutOfRangeException($"Название локации не может превышать {MaxLength} символовю", nameof(value));

            if (value.Length < MinLength)
                throw new ArgumentOutOfRangeException($"Название локации должно быть от {MinLength} до {MaxLength} символовю", nameof(value));

            return new NotEmptyName(value);
        }
    }
}
