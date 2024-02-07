using AutoMapper;
using Events.Domain.Entities;

namespace EventosApi.DTOs.Events
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            this.CreateMap<CreateEvent, Event>();
            this.CreateMap<Event, CreateEvent>();
            this.CreateMap<UpdateEvent, Event>();
        }
    }
}
