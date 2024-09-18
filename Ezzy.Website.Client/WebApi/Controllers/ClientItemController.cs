using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Client.WebApi.Controllers
{
    [ApiController]
    [Route("clientItems")]
    public class ClientItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientItem>>> GetAllClientItemsAsync()
        {
            try
            {
                var query = new GetAllClientItemQuery();
                var items = await _mediator.Send(query);
                return items != null ? Ok(items) : NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception (use your logging framework)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{pk}/{sk}", Name = "GetBypksk")]
        public async Task<ActionResult<ClientItem>> GetClientItemAsync(string pk, string sk)
        {
            try
            {
                var query = new GetClientItemQuery { pk = pk, sk = sk };
                var item = await _mediator.Send(query);
                return item != null ? Ok(item) : NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClientItemDTO>> AddClientItemAsync([FromBody] AddClientItemCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var item = await _mediator.Send(command);
                return item != null
                    ? CreatedAtRoute("GetBypksk", new { pk = item.pk, sk = item.sk }, item)
                    : BadRequest("Failed to create item.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{pk}/{sk}")]
        public async Task<ActionResult> DeleteClientItem(string pk, string sk)
        {
            try
            {
                var result = await _mediator.Send(new DeleteClientItemCommand { pk = pk, sk = sk });
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
