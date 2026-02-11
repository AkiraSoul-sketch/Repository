using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Department.ValueObject
{
	public class DepartmentPath
	{
		public const int MaxLength = 500;
		public string Value { get; }

		private DepartmentPath(string value)
		{
			Value = value;
		}

		public static DepartmentPath Create(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentException("Путь не может быть пустым.", nameof(value));
			}

			if (value.Length > MaxLength)
			{
				throw new ArgumentException($"Путь превышает {MaxLength} символов", nameof(value));
			}

			string[] parts = value.Split('.');

			foreach (string part in parts)
			{
				if (string.IsNullOrEmpty(part))
				{
					throw new ArgumentException("Путь подразделения содержит пустые части", nameof(value));
				}
			}

			return new DepartmentPath(value);
		}

		public static DepartmentPath CreateForRoot(string identifier)
		{
			return Create(identifier);
		}

		public static DepartmentPath CreateForChild(DepartmentPath ParentPath, string ChildIdentifier)
		{
			ArgumentNullException.ThrowIfNull(ParentPath);

			string newPath = $"{ParentPath.Value}.{ChildIdentifier}";
			return Create(newPath);
		}

		public short CalculateDepth()
		{
			return (short)Value.Count(c => c == '.');
		}

		public string GetParentPath()
		{
			int LastDotIndex = Value.LastIndexOf('.');
			return LastDotIndex > 0 ? Value[..LastDotIndex] : string.Empty;
		}
	}
}
