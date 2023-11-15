using AutoMapper;
using CansInnov.Application.Features.Ateliers.Commands;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;

namespace CansInnov.Client.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EventDto, CreateEventCommand>();
            CreateMap<EventDto, UpdateEventCommand>();

            CreateMap<AtelierDto, CreateAtelierCommand>();
            CreateMap<AtelierDto, UpdateAtelierCommand>();
        }
    }
}