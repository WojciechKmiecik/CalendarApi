using System;
using System.Net.Mime;
using System.Threading.Tasks;
using CalendarApi.Web.WebModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Web.Controllers
{
    [Route("calendar")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
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

            throw new NotImplementedException();
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

            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }

        [HttpGet("sort")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Sort()
        {
            throw new NotImplementedException(); // desc!
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
                message = "Please provide query parameter, epty request is not possible";
                return false;
            }
            if (id != null && id.Value < 1)
            {
                message = "Id has to be bigger than 0";
                return false;
            }
            message = string.Empty;
            return true;
        }
    }
}