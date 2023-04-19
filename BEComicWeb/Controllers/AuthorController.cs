using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BEComicWeb.Interface.StoryInterface;
using BEComicWeb.Repository;
using BEComicWeb.Model.PersonModel;
using BEComicWeb.Model.ResponseModel;

namespace BEComicWeb.Controllers
{
    [Route("author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _IAuthorRepository;

        public AuthorController(IAuthorRepository IAuthorRes)
        {
            _IAuthorRepository = IAuthorRes;
        }

        // GET: author
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Authors>>> Get()
        {
            return await Task.FromResult(_IAuthorRepository.GetAuthorDetails());
        }

        // GET author/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> Get(string id)
        {
            var Authors = await Task.FromResult(_IAuthorRepository.GetAuthorDetail(id));
            if (Authors == null)
            {
                return NotFound();
            }
            return Authors;
        }

        // POST author
        [HttpPost]
        public async Task<ActionResult<Authors>> Post(Authors author)
        {
            _IAuthorRepository.AddAuthor(author);
            return await Task.FromResult(author);
        }

        // PUT api/author/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Authors>> Put(string id, Authors author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            try
            {
                _IAuthorRepository.UpdateAuthor(author);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(author);
        }

        // DELETE api/author/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Authors>> Delete(string id)
        {
            var author = _IAuthorRepository.DeleteAuthor(id);
            return await Task.FromResult(author);
        }
        
        private bool AuthorExists(string id)
        {
            return _IAuthorRepository.CheckAuthorExists(id);
        }
    }
}
