using Business.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kindergarten_Api.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var allComments = await _commentRepository.GetAllKidComments();
            return Ok(allComments);
        }

        // implement the othert methods

    }
}
