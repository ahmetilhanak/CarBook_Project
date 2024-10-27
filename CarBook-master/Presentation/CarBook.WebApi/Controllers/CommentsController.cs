using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Application.Interfaces.Dtos.CommentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarBook.Application.Interfaces;



namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;
        private readonly ICommentRepository _commentRepository;

        public CommentsController(IGenericRepository<Comment> genericRepository, ICommentRepository commentRepository)
        {
            _genericRepository = genericRepository;
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _genericRepository.GetAll().Select(z=>new ResultCommentDto()
            {
                CommentID = z.CommentID,
                BlogID = z.BlogID,
                CreatedDate = z.CreatedDate,
                Description = z.Description,
                Name = z.Name,
                Email= z.Email,
               
            });
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateComment(CreateCommentDto data)
        {
            _genericRepository.Create(new Comment()
            {
                BlogID= data.BlogID,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                Name = data.Name,
                Email= data.Email,
                
            });
            return Ok($"It is added");
        }

        [HttpPost]
        public IActionResult CreateComment24(CreateCommentDto data)
        {
            _genericRepository.Create(new Comment()
            {
                BlogID = data.BlogID,
                CreatedDate = data.CreatedDate,
                Description = data.Description,
                Name = data.Name,
                Email= data.Email,
            });
            return Ok($"It is added");
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            var value=_genericRepository.GetById(id);
            _genericRepository.Remove(value);
            return Ok("It is deleted");
        }

        [HttpPut]
        public IActionResult UpdateComment(UpdateCommentDto data)
        {
            var value=_genericRepository.GetById(data.CommentID);
            value.BlogID = data.BlogID;
            value.CreatedDate = data.CreatedDate;   
            value.Description = data.Description;
            value.Name = data.Name;
            value.Email = data.Email;
            

            _genericRepository.Update(value);
            return Ok("It is updated");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _genericRepository.GetById(id);
            return Ok(new GetCommentByIdDto()
            {
                CommentID= values.CommentID,
                BlogID= values.BlogID,
                CreatedDate= values.CreatedDate,
                Description = values.Description,
                Name = values.Name,
                Email = values.Email,
                
            });          
        }


        [HttpGet("{id}")]
        public IActionResult CommentListByBlogId(int id)
        {
            var values = _commentRepository.CommentListByBlogId(id).Select(z => new ResultCommentDto()
            {
                CommentID = z.CommentID,
                BlogID = z.BlogID,
                CreatedDate = z.CreatedDate,
                Description = z.Description,
                Name = z.Name,
                Email = z.Email,
            });
            return Ok(values);
        }
    }
}
