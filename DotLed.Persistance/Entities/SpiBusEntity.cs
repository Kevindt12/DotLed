using DotLed.Domain.Enums;

namespace DotLed.Persistance.Entities
{
	public record SpiBusEntity : EntityBase
	{

		public int SpiBusId { get; init; }

		public int ChipEnableId { get; init; }

		public int ClockSpeed { get; init; }

		public int DataBitLength { get; init; }

		public SpiDataFlow DataFlow { get; init; }

		public SpiMode Mode { get; init; }


		public virtual GpioPinEntity? Gpio { get; init; }
	}
}
