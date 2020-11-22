
using AutoMapper;

using DotLed.Domain.Models;
using DotLed.Persistance.Entities;

using Microsoft.EntityFrameworkCore;

namespace DotLed.Persistance.Store
{

	public class LedStripStore : StoreBase<LedStrip, LedStripEntity>
	{

		public LedStripStore(IMapper mapper, DbContext context) : base(mapper, context)
		{
				
		}




	}



}
