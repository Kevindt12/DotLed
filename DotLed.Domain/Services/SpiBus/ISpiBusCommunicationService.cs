namespace DotLed.Domain.Services.Bus
{
	public interface ISpiBusCommunicationService : IBusCommunicationService
	{
		int SpiBusId { get; }



	}
}