using System.Threading.Tasks;
using CQRS.Application.Categories.Commands;
using CQRS.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(
                IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var Category = await _mediator.Send(new GetCategoryQuery() { Id = categoryId });
            return Ok(Category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand input)
        {
            var isCreated = await _mediator.Send(input);
            return Ok(isCreated);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateCategory(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> Delete(int categoryId)
        {
            await _mediator.Send(new DeleteCategoryCommand { Id = categoryId });
            return NoContent();
        }
    }
}