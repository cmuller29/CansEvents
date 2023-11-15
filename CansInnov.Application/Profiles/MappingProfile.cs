using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CansInnov.Application.Features.Ateliers.Commands;
using CansInnov.Application.Features.Ateliers.Dtos;
using CansInnov.Application.Features.Events.Commands;
using CansInnov.Application.Features.Events.Dtos;
using CansInnov.Persistence.Models;

namespace CansInnov.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<CreateEventCommand, Event>().ReverseMap();
            CreateMap<UpdateEventCommand, Event>().ReverseMap();

            CreateMap<Atelier, AtelierDto>();
            CreateMap<CreateAtelierCommand, Atelier>();
        }
    }
}