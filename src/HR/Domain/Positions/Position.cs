using System;
using System.Collections.Generic;
using Domain.Positions.ValueObject;
using Domain.Shared;

namespace Domain.Positions
{
	public sealed class Position
	{
		private readonly List<PositionName> names = [];
		public PositionId Id { get; }

		public PositionName Name { get; set; }

		public EntityLifeTime LifeTime { get; set; }

		public PositionDescription Description { get; }

		public Position(PositionId id, PositionName name, EntityLifeTime lifeTime, PositionDescription description)
		{
			this.Id = id;
			this.Name = name;
			this.LifeTime = lifeTime;
			this.Description = description;
		}

		public void AddPosition(PositionName name)
		{
			if (AlreadyContains(name))
			{
				throw new InvalidOperationException("Подобная должность уже существует");
			}
			names.Add(name);
		}

		private bool AlreadyContains(PositionName name)
		{
			return names.Contains(name);
		}

		public void ChangePositionName(PositionName newname)
		{
			if (!LifeTime.IsActive)
			{
				throw new InvalidOperationException("Объект удален");
			}

			Name = newname;

			LifeTime = LifeTime.Update();
		}
	}
}
