using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using DotLed.Persistance.Entities;

using Microsoft.EntityFrameworkCore;

namespace DotLed.Persistance.Store
{
	public abstract class StoreBase<TModel, TEntity> : IStore<TModel>
		where TEntity : EntityBase, new()
	{

		protected DbSet<TEntity> _entities;

		public IMapper Mapper { get; init; }


		public StoreBase(IMapper mapper, DbContext dbContext)
		{
			_entities = dbContext.Set<TEntity>();
			Mapper = mapper;
		}

		public virtual void Add(TModel entity)
		{
			_entities.Add(Mapper.Map<TModel, TEntity>(entity));
		}

		public virtual async Task<TModel> FindByIdAsync(string key)
		{
			return Mapper.Map<TEntity, TModel>(await _entities.SingleOrDefaultAsync(x => x.Id == Guid.Parse(key)));
		}


		public async virtual IAsyncEnumerable<TModel> GetAsync()
		{
			await foreach (TEntity entity in _entities.AsAsyncEnumerable())
			{
				yield return Mapper.Map<TEntity, TModel>(entity);
			} 
		}

		public virtual void Remove(TModel entity)
		{
			_entities.Remove(Mapper.Map<TModel, TEntity>(entity));
		}

		public virtual void Update(TModel entity)
		{
			_entities.Update(Mapper.Map<TModel, TEntity>(entity));
		}
	}
}
