using System.Threading.Tasks;

namespace DotLed.Persistance
{
	public interface IUnitOfWork
	{


		Task SaveAsync();
	}
}
