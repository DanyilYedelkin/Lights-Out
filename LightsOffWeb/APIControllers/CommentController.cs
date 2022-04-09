using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightsOffCore.Service;
using LightsOffCore.Entity;

namespace LightsOffWeb.APIControllers
{
    //https://localhost:44384/api/Comment/
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService commentService = new CommentServiceEF();

        //GET: /api/Comment
        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            return commentService.GetComments();
        }

        //POST: /api/Comment
        [HttpPost]
        public void PostComment([FromBody]Comment comment)
        {
            //comment.PlayedAt = DateTime.Now;
            commentService.AddComment(comment);
        }
    }
}
