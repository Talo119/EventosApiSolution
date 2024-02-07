using AutoMapper;
using EventosApi.Common.Error;
using EventosApi.DTOs.Events;
using EventosApi.Respository;
using Events.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class EventsController : ControllerBase
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public EventsController(IGenericRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetListEvents()
        {
            try
            {
                var list_events = await _eventRepository.GetAllAsync();
                if (list_events == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Error = new Error
                        {
                            Code = ((int)HttpStatusCode.NotFound).ToString(),
                            Target = nameof(Event),
                            Message = "Not found"
                        }
                    });
                }

                return Ok(list_events);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                        Target = nameof(Event),
                        Message = "Internal server error."
                    }
                });
            }
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetEvent(int id)
        {
            try
            {
                var event_by_id = await _eventRepository.GetAsync(id);
                if (event_by_id == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Error = new Error
                        {
                            Code = ((int)HttpStatusCode.NotFound).ToString(),
                            Target = nameof(Event),
                            Message = "Not found"
                        }
                    });
                }

                return Ok(event_by_id);
            }
            catch (Exception ex)
            {

                return this.StatusCode(500, new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                        Target = nameof(Event),
                        Message = "Internal server error."
                    }
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(CreateEvent createEvent)
        {
            try
            {
                var new_event = await _eventRepository.PostAsync(_mapper.Map<Event>(createEvent));
                return Ok(new_event);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                        Target = nameof(Event),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEvent updateEvent)
        {
            try
            {
                if (id != updateEvent.Id)
                {
                    return BadRequest();
                }

                var update_event = await _eventRepository.PutAsync(id, _mapper.Map<Event>(updateEvent));

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, new ErrorResponse
                {
                    Error = new Error   
                    {
                        Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                        Target = nameof(Event),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                await _eventRepository.DeleteAsync(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, new ErrorResponse
                {
                    Error = new Error
                    {
                        Code = ((int)HttpStatusCode.InternalServerError).ToString(),
                        Target = nameof(Event),
                        Message = ex.Message
                    }
                });
            }
            
        }

    }
}
