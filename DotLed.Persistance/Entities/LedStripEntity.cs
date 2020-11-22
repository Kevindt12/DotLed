namespace DotLed.Persistance.Entities
{
	public record LedStripEntity : EntityBase
	{

		public string Name { get; init; }


		public int Length { get; init; }


		public virtual SpiBusEntity? SpiBus { get; init; }


	}
}
