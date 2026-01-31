using Domain.Department.ValueObject;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Department
{
    public class Department
    {
        public Department(DepartmentId id, DepartmentId parentid, NotEmptyName name, DepartmentIdentifier identifier, DepartmentPath path, Depth depth, EntityLifeTime lifeTime)
        {
            Id = id;
            ParentId = parentid;
            Name = name;
            Depth = depth;
            Identifier = identifier;
            Path = path;
            LifeTime = lifeTime;
        }
        public DepartmentId Id { get; }
        public DepartmentId ParentId { get; }
        public NotEmptyName Name { get; }
        public DepartmentIdentifier Identifier { get; }
        public DepartmentPath Path { get; }
        public Depth Depth { get; }
        public EntityLifeTime LifeTime { get; }
    }
}
