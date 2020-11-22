using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotLed.Persistance.Store
{
	public interface IStore<TModel> 
	{

		IAsyncEnumerable<TModel> GetAsync();

		Task<TModel> FindByIdAsync(string key);


		void Add(TModel entity);

		void Update(TModel entity);

		void Remove(TModel entity);

	}
}
