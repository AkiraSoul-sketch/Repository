using System;
using System.Collections.Generic;
using System.Text;
using Domain.Department.ValueObject;

namespace Domain.Positions.ValueObject
{
	public sealed record PositionName
	{
		public const int MaxLength = 128;
		public const int MinLength = 3;

		public string Value { get; }

		private PositionName(string value)
		{
			Value = value;
		}

		public static PositionName Create(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentNullException(nameof(value), "Название подразделения не может быть пустым");
			}

			if (value.Length > MaxLength)
			{
				throw new ArgumentOutOfRangeException(
					nameof(value),
					$"Название подразделения не может превышать {MaxLength} символов."
				);
			}

			if (value.Length < MinLength)
			{
				throw new ArgumentOutOfRangeException(
					nameof(value),
					$"Название подразделения должно быть от {MinLength} до {MaxLength} символов."
				);
			}

			return new PositionName(value);
		}

		public static PositionName ChangeName(string name)
		{
			PositionName newname = Create(name);
			return newname;
		}
	}
}
