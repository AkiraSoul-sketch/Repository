using System;
using System.Collections.Generic;
using System.Text;
using Domain.Shared;

namespace Domain.Department.ValueObject
{
	public class DepartmentName
	{
		public const int MaxLength = 128;
		public const int MinLength = 3;

		public string Value { get; }

		private DepartmentName(string value)
		{
			Value = value;
		}

		public static DepartmentName Create(string value)
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

			return new DepartmentName(value);
		}
	}
}
