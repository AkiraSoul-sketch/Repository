using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.LocationContext.ValueObjects
{
	public sealed record LocationId
	{
		Guid Value { get; }

		private LocationId(Guid value)
		{
			Value = value;
		}

		public static LocationId Create(Guid value)
		{
			if (value == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(value), "Идентификатор не может быть пустым.");
			}

			return new LocationId(value);
		}
	}
}
