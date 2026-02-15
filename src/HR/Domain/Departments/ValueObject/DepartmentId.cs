using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Departments.ValueObject
{
    public class DepartmentId
    {
        public Guid Value { get; }

        private DepartmentId(Guid value)
        {
            Value = value;
        }

        public static DepartmentId Create(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("Идентификатор не может быть пустым.", nameof(value));
            }
            return new DepartmentId(value);
        }

        internal static DepartmentId Create()
        {
            throw new NotImplementedException();
        }
    }
}
