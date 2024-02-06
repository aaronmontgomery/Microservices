using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DavesList.Services;
using DavesList.Models;

namespace DavesList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        
        [Authorize]
        [HttpPost]
        [Route("/addpost")]
        public IActionResult AddPost([FromBody] AddPostRequest addPostRequest)
        {
            IActionResult actionResult;

            try
            {
                actionResult = Ok(_postService.AddPost(addPostRequest.Post!, addPostRequest.Title!));
            }

            catch
            {
                actionResult = BadRequest();
            }

            return actionResult;
        }
        
        [HttpGet]
        [Route("/getposts")]
        public IActionResult GetPosts()
        {
            IActionResult actionResult;
            
            try
            {
                actionResult = Ok(_postService.GetPosts(25));
            }

            catch
            {
                actionResult = BadRequest();
            }

            return actionResult;
        }
    }
}
