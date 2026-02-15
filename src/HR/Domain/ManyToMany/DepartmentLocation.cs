using System;
using System.Collections.Generic;
using System.Text;
using Domain.Departments;
using Domain.Departments.ValueObject;
using Domain.LocationContext;
using Domain.LocationContext.ValueObjects;

namespace Domain.ManyToMany
{
	public class DepartmentLocation
	{
		public DepartmentId DepartmentId { get; }
		public LocationId LocationId { get; }
		public Location Location { get; }
		public Department Department { get; }

		public DepartmentLocation(
			DepartmentId Departmentid,
			LocationId LocationId,
			Location location,
			Department department
		)
		{
			this.DepartmentId = Departmentid;
			this.LocationId = LocationId;
			this.Location = location;
			this.Department = department;
		}
	}
}
