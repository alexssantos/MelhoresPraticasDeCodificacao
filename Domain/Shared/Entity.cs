using System;

namespace Domain.Shared
{
	public abstract class Entity
	{
		public Entity(Guid? id)
		{
			Id = id ?? Guid.NewGuid();
		}

		public Guid Id { get; private set; }
	}
}
