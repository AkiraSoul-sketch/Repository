using Domain.Departments.ValueObject;
using Domain.LocationContext.ValueObjects;
using Domain.LocationContext;
using Domain.ManyToMany;
using Domain.Positions;
using Domain.Shared;


namespace Domain.Departments
{
	public class Department
	{
		public DepartmentId Id { get; }
		public DepartmentId? ParentId { get; }
		public DepartmentName Name { get; }
		public DepartmentIdentifier Identifier { get; }
		public DepartmentPath Path { get; }
		public DepartmentDepth Depth { get; }
		public EntityLifeTime LifeTime { get; set; }
		private readonly List<Department> departments = [];
		private readonly List<DepartmentPosition> DepartmentPosition = [];
		private readonly List<DepartmentLocation> locations = [];

		public Department(
			DepartmentId id,
			DepartmentId parentid,
			DepartmentName name,
			DepartmentIdentifier identifier,
			DepartmentPath path,
			DepartmentDepth depth,
			EntityLifeTime lifeTime
		)
		{
			this.Id = id;
			this.ParentId = parentid;
			this.Name = name;
			this.Depth = depth;
			this.Identifier = identifier;
			this.Path = path;
			this.LifeTime = lifeTime;
		}

		public Department(
			DepartmentId id,
			DepartmentName name,
			DepartmentIdentifier identifier,
			EntityLifeTime lifeTime
		)
		{
			this.Id = id;
			this.ParentId = null;
			this.Name = name;
			this.Depth = DepartmentDepth.Create(1);
			this.Identifier = identifier;
			this.Path = DepartmentPath.Create(identifier.Value);
			this.LifeTime = lifeTime;
		}

		public static Department CreateRoot(DepartmentName name, DepartmentIdentifier Identifier, bool IsActive = true)
		{
			DepartmentId id = DepartmentId.Create();
			DepartmentPath path = DepartmentPath.CreateForRoot(Identifier.Value);
			DepartmentDepth depth = DepartmentDepth.CalculateFromPath(path);
			EntityLifeTime lifetime = EntityLifeTime.Create(
				createdAt: DateTime.UtcNow,
				updatedAt: DateTime.UtcNow,
				isActive: IsActive
			);

			return new Department(id, name, Identifier, lifetime);
		}

		public bool IsRoot()
		{
			return ParentId == null;
		}

		public bool IsChildOf(Department child)
		{
			if (child.ParentId == null)
			{
				return false;
			}
			if (child.ParentId == Id)
			{
				return true;
			}

			string pathchild = Name.Value;
			string pathparent = Name.Value;

			if (pathchild.Contains(pathparent, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			return false;
		}

		public static Department CreateChild(Department parent, DepartmentName name, DepartmentIdentifier identifier)
		{
			DepartmentId id = DepartmentId.Create();
			DepartmentPath path = DepartmentPath.Create(parent.Path.Value + "/" + identifier.Value);
			DepartmentDepth depth = DepartmentDepth.CalculateFromPath(path);
			EntityLifeTime lifetime = EntityLifeTime.Create(
				createdAt: DateTime.UtcNow,
				updatedAt: DateTime.UtcNow,
				isActive: true
			);
			return new Department(id, parentid: parent.Id, name, identifier, path, depth, lifetime);
		}

		public void AddChild(Department child)
		{
			if (IsChildOf(child))
			{
				throw new InvalidOperationException("Объект уже является дочерним объектом");
			}
			if (child.ParentId != null)
			{
				throw new InvalidOperationException("Объект не является дочерним объектом");
			}

			departments.Add(child);
		}

		public void AddPosition(Position position)
		{
			ArgumentNullException.ThrowIfNull(position);

			if (DepartmentPosition.Any(dp => dp.PositionId == position.Id))
			{
				throw new InvalidOperationException("Данная позиция уже существует.");
			}

			DepartmentPosition.Add(new DepartmentPosition(
				departmentid: Id,
                positionid: position.Id,
                department: this,
                position: position
            ));
		}

		public void AddLocation(Location location)
		{
			ArgumentNullException.ThrowIfNull(location);
			
			if (locations.Any(l => l.LocationId == location.Id))
			{
				throw new InvalidOperationException("Данная локация уже существует.");
			}

			locations.Add(new DepartmentLocation(
				Departmentid: Id,
				LocationId: location.Id,
				location: location,
				department: this
			));
		}
	}
}
