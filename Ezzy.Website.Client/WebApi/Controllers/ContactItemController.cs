using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Client.WebApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ContactItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactItem>>> GetAllItemsAsync()
        {
            var query = new GetAllContactItemQuery();
            var items = await _mediator.Send(query);
            if (items != null)
            {
                return Ok(items);
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<ContactItem>> GetItemAsync(string id)
        {
            var query = new GetContactItemQuery { Id = id };
            var item = await _mediator.Send(query);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<ContactItemDTO>> AddItemAsync([FromBody] AddContactItemCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            var item = await _mediator.Send(command);
            if (item != null)
            {
                return CreatedAtRoute("GetById", new { id = item.Id }, item);
            }

            return BadRequest("Failed to create item.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactItem(string id)
        {
            var result = await _mediator.Send(new DeleteContactItemCommand { Id = id });
            if (result)
            {
                return NoContent(); 
            }

            return NotFound();
        }
    }
}
