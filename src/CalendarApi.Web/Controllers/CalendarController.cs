using System;
using System.Net.Mime;
using System.Threading.Tasks;
using CalendarApi.Definition.Services;
using CalendarApi.Web.Mappers;
using CalendarApi.Web.WebModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Web.Controllers
{
    [Route("calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _service;

        public CalendarController(ICalendarService service)
        {
            _service = service;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddEvent([FromBody]EventWebModel model)
        {
            if (!ValidateAddEventRequest(model, out string mess))
            {
                return BadRequest(mess);
            }

            await _service.AddEvent(model.Map());
            return Accepted();
        }

        [HttpDelete("{id:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            if (id < 1)
            {
                return NotFound("Id not exists");
            }

            var result = await _service.DeleteEvent(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EditEvent(long id, [FromBody] EventWebModel model)
        {
            if (!ValidateAddEventRequest(model, out string mess))
            {
                return BadRequest("mess");
            }
            if (model.Id < 1)
            {
                return BadRequest("Please supply the correct event Id");
            }

            var result = await _service.UpdateEvent(id, model.Map());
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(result);
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll(sortedByDescTime: false));
        }

        [HttpGet("query")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Query(string eventOrganizer, long? id, string location, string name)
        {
            if (ValidateQueryRequest(eventOrganizer, id, location, name, out string message))
            {
                return BadRequest(message);
            }

            return Ok(await _service.GetQuery(eventOrganizer, id, location, name));
        }

        [HttpGet("sort")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Sort()
        {
            return Ok(await _service.GetAll(sortedByDescTime: true));
        }

        private bool ValidateAddEventRequest(EventWebModel model, out string message)
        {
            //use fluent validations, or move it somewhere, to validation folder
            if (model == null)
            {
                // merssages should come form resx, or any other resource, to make translations eeasier
                message = "Model cannot be null";
                return false;
            }
            if (true)
            {

            }
            message = string.Empty;
            return true;
        }
        private bool ValidateQueryRequest(string eventOrganizer, long? id, string location, string name, out string message)
        {
            if (string.IsNullOrWhiteSpace(eventOrganizer) && string.IsNullOrWhiteSpace(location) && string.IsNullOrWhiteSpace(name) && !id.HasValue)
            {
                // think about use resx file for translations
                message = "Please provide query parameter, empty request is not possible";
                return false;
            }
            if (id != null && id.Value < 1)
            {
                message = "Id has to be bigger than 0";
                return false;
            }
            // validate if only one is passed
            //if (true)
            //{

            //}
            message = string.Empty;
            return true;
        }
    }
}