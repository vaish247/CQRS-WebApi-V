using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ezzy.Website.Core.Application.Commands;
using Ezzy.Website.Core.Application.Queries;
using Ezzy.Website.Infrastructure.Domain.DTO;
using Ezzy.Website.Infrastructure.Domain.Entities;

namespace Ezzy.Website.Client.WebApi.Controllers
{
    [ApiController]
    [Route("caseStudyItems")]
    public class CaseStudyItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CaseStudyItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseStudyItem>>> GetAllCaseStudyItemsAsync()
        {
            try
            {
                var query = new GetAllCaseStudyItemQuery();
                var items = await _mediator.Send(query);
                return items != null ? Ok(items) : NotFound();
            }
            catch (Exception ex)
            {
                // Log the exception (use your logging framework)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{pk}/{sk}", Name = "caseStudyItemsGetBypksk")]
        public async Task<ActionResult<CaseStudyItem>> GetCaseStudyItemAsync(string pk, string sk)
        {
            try
            {
                var query = new GetCaseStudyItemQuery { pk = pk, sk = sk };
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
        public async Task<ActionResult<CaseStudyItemDTO>> AddCaseStudyItemAsync([FromBody] AddCaseStudyItemCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var item = await _mediator.Send(command);
                return item != null
                    ? CreatedAtRoute("caseStudyItemsGetBypksk", new { pk = item.pk, sk = item.sk }, item)
                    : BadRequest("Failed to create item.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{pk}/{sk}")]
        public async Task<ActionResult> DeleteCaseStudyItem(string pk, string sk)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCaseStudyItemCommand { pk = pk, sk = sk });
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
