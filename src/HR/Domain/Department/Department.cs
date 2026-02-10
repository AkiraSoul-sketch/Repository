using Domain.Department.ValueObject;
using Domain.LocationContext;
using Domain.Positions;
using Domain.Shared;

namespace Domain.Department
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

		private readonly List<Position> positions = [];

		public void AddPosition(Position position)
		{
			foreach (Position p in positions)
			{
				if (p.Name == position.Name)
				{
					throw new ArgumentException("Подобное название позиции уже существуетю");
				}

				if (p.Id == position.Id)
				{
					throw new ArgumentException("Данная позиция уже существует.");
				}
			}
			positions.Add(position);

			LifeTime = LifeTime.Update();
		}

		private readonly List<Location> offices = [];

		public void AddOffice(Location office)
		{
			foreach (Location p in offices)
			{
				if (p.Name == office.Name)
				{
					throw new ArgumentException("Название данной локации уже есть в базе.");
				}

				if (p.Address == office.Address)
				{
					throw new ArgumentException("Данный адрес уже есть в базе.");
				}

				if (p.Id == office.Id)
				{
					throw new ArgumentException("Данная локация уже есть в базе.");
				}
			}

			offices.Add(office);

			LifeTime = LifeTime.Update();
		}
	}
}
