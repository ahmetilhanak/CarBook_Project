using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQueryRequest());
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> BlogListWithAuthorAndCategory()
        {
            var values = await _mediator.Send(new GetBlogWithCategoryAndAuthorQueryRequest());
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQueryRequest(id));
            return Ok(values);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateBlog(CreateBlogCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Added");
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommandRequest(id));

            return Ok("It is deleted");
        }


        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommandRequest command)
        {
            await _mediator.Send(command);
            return Ok("It is Updated");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> BlogSomeListWithAuthorAndCategory(int id)
        {
            var values = await _mediator.Send(new GetSomeBlogWithCategoryAndAuthorQueryRequest(id));
            return Ok(values);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogByIdListWithAuthorAndCategory(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdWithCategoryAndAuthorQueryRequest(id));
            return Ok(values);
        }
    }
}
