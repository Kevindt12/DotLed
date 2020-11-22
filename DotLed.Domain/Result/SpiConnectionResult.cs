
using DotLed.Domain.Enums;

namespace DotLed.Domain.Result
{
	public sealed class SpiConnectionResult
	{
		public bool Succeded { get; private set; }

		public SpiConnectionErrors Error { get; set; }

		private SpiConnectionResult()
		{
			Succeded = true;
		}

		private SpiConnectionResult(SpiConnectionErrors error)
		{

		}

		public static SpiConnectionResult Success => new SpiConnectionResult();

		public static SpiConnectionResult Failed(SpiConnectionErrors error) => new SpiConnectionResult(error);





	}
}
