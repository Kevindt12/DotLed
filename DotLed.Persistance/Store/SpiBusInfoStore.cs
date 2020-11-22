
using AutoMapper;

using DotLed.Domain.Models;
using DotLed.Persistance.Entities;

using Microsoft.EntityFrameworkCore;

namespace DotLed.Persistance.Store
{
	public class SpiBusInfoStore : StoreBase<SpiBusInfo, SpiBusEntity>
	{
		public SpiBusInfoStore(IMapper mapper, DbContext dbcontext) : base(mapper, dbcontext)
		{

		}

	}
}
