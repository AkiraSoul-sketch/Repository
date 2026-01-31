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
                throw new ArgumentNullException(
                    nameof(value),
                    "Название локации не может быть пустым"
                );

            if (value.Length > MaxLength)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Название локации не может превышать {MaxLength} символовю"
                );

            if (value.Length < MinLength)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    $"Название локации должно быть от {MinLength} до {MaxLength} символовю"
                );

            return new NotEmptyName(value);
        }
    }
}
