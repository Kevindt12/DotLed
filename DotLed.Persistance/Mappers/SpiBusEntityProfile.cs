
using AutoMapper;

using DotLed.Domain.Models;
using DotLed.Persistance.Entities;

namespace DotLed.Persistance.Mappers
{
	public class SpiBusEntityProfile : Profile
	{


		public SpiBusEntityProfile()
		{
			CreateMap<SpiBusEntity, SpiBusInfo>()
				.ForMember(dest => dest.Settings.ClockSpeed, opt => opt.MapFrom(srs => srs.ClockSpeed))
				.ForMember(dest => dest.Settings.DataBitLength, opt => opt.MapFrom(srs => srs.DataBitLength))
				.ForMember(dest => dest.Settings.DataFlow, opt => opt.MapFrom(srs => srs.DataFlow))
				.ForMember(dest => dest.Settings.SpiMode, opt => opt.MapFrom(srs => srs.Mode))
				.ReverseMap();
		}

	}
}
