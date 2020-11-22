namespace DotLed.Persistance.Entities
{
	public record GpioPinEntity : EntityBase
	{
		public byte Mosi { get; init; }

		public byte Clock { get; init; }

		public byte ChipEnable { get; init; }
	}
}
