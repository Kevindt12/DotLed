using System;

using AutoMapper;

using DotLed.Domain.Models;
using DotLed.Infrastructure.Data;

namespace DotLed.Infrastructure.Mappers
{
	public class DeviceFileProfile : Profile
	{


		public DeviceFileProfile()
		{
			CreateMap<DeviceFile, Device>()
				.ForMember(dest => dest.OS, opt => opt.MapFrom(df => Environment.OSVersion))
				.ReverseMap();
		}
	}
}
