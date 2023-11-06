using LightweightToDoLesson11.Models;
using LightweightToDoLesson11.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LightweightToDoLesson11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private IPostsServicese _postsServicese;

        public PostsController(IPostsServicese postsServicese)
        {
            _postsServicese = postsServicese;
        }

        [HttpPost]
        public PostModele Creat(PostModele model)
        {
          return _postsServicese.Create(model);
        }
        [HttpPatch]
        public PostModele Update(PostModele model)
        {
            return _postsServicese.Update(model);
        }
        [HttpGet("{id}")]
        public PostModele Get(int id)
        {
            return _postsServicese.Get(id);
        }
        [HttpGet]
        public IEnumerable<PostModele> GetAll()
        {
            return _postsServicese.Get();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postsServicese.Delete(id);

            return Ok();
        }
    }
}
