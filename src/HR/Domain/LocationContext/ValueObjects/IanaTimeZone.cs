using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.LocationContext.ValueObjects
{
    public sealed class IanaTimeZone
    {
        public string Value { get; }

        private IanaTimeZone(string value)
        {
            Value = value;
        }

        public static IanaTimeZone Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(
                    nameof(value),
                    "IanaTimeZone не может быть нулем или пустой строкой."
                );
            }

            if (value.Contains('/', StringComparison.Ordinal))
            {
                string[] parts = value.Split('/');
                if (parts.Length != 2)
                {
                    throw new ArgumentException(
                        "временная зона не соответсвует временной зоне IANA",
                        nameof(value)
                    );
                }

                if (parts.Any(p => string.IsNullOrWhiteSpace(p)))
                    throw new ArgumentException(
                        "временная зона не соответсвует временной зоне IANA",
                        nameof(value)
                    );

                return new IanaTimeZone(value);
            }

            throw new ArgumentException(
                "временная зона не соответсвует временной зоне IANA",
                nameof(value)
            );
        }
    }
}
