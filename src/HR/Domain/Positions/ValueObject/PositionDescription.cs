using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Positions.ValueObject
{
	public sealed record PositionDescription
	{
		public const int MaxLength = 500;
		public string Value { get; }

		private PositionDescription(string value)
		{
			Value = value;
		}

		public static PositionDescription Create(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(nameof(value), "Значение было пустым.");
			}

			if (value.Length > MaxLength)
			{
				throw new ArgumentException("Строка привышает длину символов.", nameof(value));
			}

			return new PositionDescription(value);
		}
	}
}
