using System;

namespace DotLed.Persistance.Entities
{
	public abstract record EntityBase
	{

		public Guid Id { get; init; }


	}
}
