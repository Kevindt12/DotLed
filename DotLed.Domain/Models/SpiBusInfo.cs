using DotLed.Domain.ValueObjects;

namespace DotLed.Domain.Models
{
	public record SpiBusInfo
	{

		public int SpiBusId { get; init; }

		public int ChipEnableId { get; init; }

		public SpiBusSettings Settings { get; init; }

		public GpioPin Gpio { get; init; }
	}
}
