using System;
using System.Collections.Generic;
using System.Text;
using Domain.Departments;
using Domain.Departments.ValueObject;
using Domain.Positions;
using Domain.Positions.ValueObject;
using Domain.Shared;

namespace Domain.ManyToMany
{
	public class DepartmentPosition
	{
		public DepartmentId DepartmentId { get; }
		public PositionId PositionId { get; }
		public Department Department { get; }
		public Position Position { get; }

		public DepartmentPosition(
			DepartmentId departmentid,
			PositionId positionid,
			Department department,
			Position position
		)
		{
			DepartmentId = departmentid;
			PositionId = positionid;
			Position = position;
			Department = department;
		}
	}
}
